using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BasicInformation.Student_CourseItem.StudentExtendControls
{
    public partial class EditScore : BaseForm
    {
        Dictionary<string, SCETakeRecord> _sce_takes;
        Dictionary<string, string> _courseToScAttend;

        string _studentID;

        public EditScore(int schoolYear, int semester, string studentId)
        {
            InitializeComponent();

            _sce_takes = new Dictionary<string, SCETakeRecord>();
            _courseToScAttend = new Dictionary<string, string>();
            _studentID = studentId;

            foreach (SCETakeRecord sce in K12.Data.SCETake.SelectByStudentID(studentId))
            {
                string key = sce.RefCourseID + "_" + sce.RefExamID;
                if (!_sce_takes.ContainsKey(key))
                    _sce_takes.Add(key, sce);
            }

            //取得某一個學生的所有修課紀錄包含所有的學年度學期

            List<SCAttendRecord> scattend = K12.Data.SCAttend.SelectByStudentID(studentId);
            //把所有的課程ID收集到一個LIST裡面，得到所有課程ID
            List<string> courseIds = new List<string>();

            foreach (SCAttendRecord sc in scattend)
            {
                if (!_courseToScAttend.ContainsKey(sc.RefCourseID))
                    _courseToScAttend.Add(sc.RefCourseID, sc.ID);
                courseIds.Add(sc.RefCourseID);
            }

            //接下來，課程ID把所有的課程抓下來

            List<CourseRecord> courses = Course.SelectByIDs(courseIds);
            courses.Sort(delegate(CourseRecord x, CourseRecord y)
            {
                return x.Name.CompareTo(y.Name);
            });

            //把不要的學年度學期過濾掉 印出
            foreach (CourseRecord cr in courses)
            {
                if (cr.SchoolYear != schoolYear)
                    continue;

                if (cr.Semester != semester)
                    continue;

                DataGridViewRow row = new DataGridViewRow();
                string score1 = _sce_takes.ContainsKey(cr.ID + "_1") ? GetScore(_sce_takes[cr.ID + "_1"]) : string.Empty;
                string score2 = _sce_takes.ContainsKey(cr.ID + "_2") ? GetScore(_sce_takes[cr.ID + "_2"]) : string.Empty;
                row.CreateCells(dataGridViewX1, cr.Name, score1, score2);
                row.Tag = cr.ID;

                dataGridViewX1.Rows.Add(row);
            }
        }

        private void EditScore_Load(object sender, EventArgs e)
        {

        }

        private string GetScore(SCETakeRecord sce)
        {
            XmlElement elem = sce.ToXML().SelectSingleNode("Extension/Extension/Score") as XmlElement;

            string score = elem == null ? string.Empty : elem.InnerText;

            return score;
        }


        private void SetScore(SCETakeRecord sce, string score)
        {
            XmlElement root = sce.ToXML();
            XmlElement elem = root.SelectSingleNode("Extension/Extension/Score") as XmlElement;

            decimal d;
            decimal.TryParse(score, out d);

            if (elem != null)
            {
                elem.InnerText = d + "";
            }

            sce.Load(root);
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            List<SCETakeRecord> insert = new List<SCETakeRecord>();
            List<SCETakeRecord> update = new List<SCETakeRecord>();
            List<SCETakeRecord> delete = new List<SCETakeRecord>();

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string course_ID = row.Tag + "";
                string sc_attend_id = _courseToScAttend.ContainsKey(course_ID) ? _courseToScAttend[course_ID] : string.Empty;
                decimal a;
                string key1 = row.Tag + "_1";
                string key2 = row.Tag + "_2";
                string score1 = row.Cells[Col_Midtern.Index].Value + "";
                string score2 = row.Cells[Col_Final.Index].Value + "";
               
                bool result1 = decimal.TryParse(score1, out a);
                bool result2 = decimal.TryParse(score2, out a);

                if (score1 == "")
                {
                    row.Cells[Col_Midtern.Index].ErrorText = "";
                }
                else
                {
                    row.Cells[Col_Midtern.Index].ErrorText = "";
                    if (!result1)
                    {

                        row.Cells[Col_Midtern.Index].ErrorText = "欄位必須為數字";
                    }
                }

                if (score2 == "")
                {
                    row.Cells[Col_Final.Index].ErrorText = "";
                }
                else
                {
                    row.Cells[Col_Final.Index].ErrorText = "";
                    if (!result2)
                    {
                        if (score2 == "") continue;
                        row.Cells[Col_Final.Index].ErrorText = "欄位必須為數字";
                    }
                }
                SCETakeRecord sce_1 = _sce_takes.ContainsKey(key1) ? _sce_takes[key1] : null;
                SCETakeRecord sce_2 = _sce_takes.ContainsKey(key2) ? _sce_takes[key2] : null;

                if (sce_1 != null)
                {
                    if (score1 != "")
                    {
                        //有值更改 update
                        SetScore(sce_1, score1);
                        update.Add(sce_1);
                    }
                    //有值刪值 Delete
                    else
                        delete.Add(sce_1);
                }
                else
                {
                    //沒值新增值進入 insert
                    if (sc_attend_id != "" && score1 != "")
                    {
                        sce_1 = new SCETakeRecord();
                        sce_1.RefSCAttendID = sc_attend_id;
                        sce_1.RefExamID = "1";
                        sce_1.RefStudentID = _studentID;
                        sce_1.RefCourseID = course_ID;
                        SetScore(sce_1, score1);
                        insert.Add(sce_1);
                    }
                }

                if (sce_2 != null)
                {
                    if (score2 != "")
                    {
                        SetScore(sce_2, score2);
                        update.Add(sce_2);
                    }
                    else
                        delete.Add(sce_2);
                }
                else
                {
                    if (sc_attend_id != "" && score2 != "")
                    {
                        sce_2 = new SCETakeRecord();
                        sce_2.RefSCAttendID = sc_attend_id;
                        sce_2.RefExamID = "2";
                        sce_2.RefStudentID = _studentID;
                        sce_2.RefCourseID = course_ID;
                        SetScore(sce_2, score2);
                        insert.Add(sce_2);
                    }
                }
            }

            bool pass = true;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells[Col_Midtern.Index].ErrorText != "")
                {
                    pass = false;
                }

                if (row.Cells[Col_Final.Index].ErrorText != "")
                {
                    pass = false;
                }
            }

            if (pass)
            {
                if (insert.Count > 0)
                    K12.Data.SCETake.Insert(insert);

                if (update.Count > 0)
                    K12.Data.SCETake.Update(update);

                if (delete.Count > 0)
                    K12.Data.SCETake.Delete(delete);
                this.Close();
            }
            else
            {
                MsgBox.Show("請檢查資料格式正確");
            }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
