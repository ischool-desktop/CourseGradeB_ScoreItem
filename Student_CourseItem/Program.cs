using FISCA;
using FISCA.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInformation.Student_CourseItem
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            FeatureAce UserPermission = FISCA.Permission.UserAcl.Current[Permissions.學生修課];
            if (UserPermission.Editable || UserPermission.Viewable)
                K12.Presentation.NLDPanels.Student.AddDetailBulider(new FISCA.Presentation.DetailBulider<CourseScoreItem>());


            FISCA.Permission.Catalog detail1 = RoleAclSource.Instance["學生"]["資料項目"];
            detail1.Add(new DetailItemFeature(Permissions.學生修課, "學生修課"));
        }
    }
}
