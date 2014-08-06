using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicInformation.Student_CourseItem
{
    class Permissions
    {
        public static string 學生修課 { get { return "JHSchool.Student.Detail0052"; } }
        public static bool 學生修課權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[學生修課].Executable;
            }
        }
    }
}
