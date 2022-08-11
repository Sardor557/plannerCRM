using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using FileSystemData.BusinessObjects;
using plannerCRM.Module.Utils;
using System.ComponentModel;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.tbAnalizeResult")]
    public class tbAnalizeResult : BaseModel
    {
        public tbAnalizeResult(Session session) : base(session)
        {
        }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), ImmediatePostData]
        public FileSystemStoreObject File
        {
            get { return GetPropertyValue<FileSystemStoreObject>("File"); }
            set { SetPropertyValue<FileSystemStoreObject>("File", value); }
        }


        private tbUser fUser;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association("Analize-User")]
        public tbUser User
        {
            get { return fUser; }
            set { SetPropertyValue(nameof(User), ref fUser, value); }
        }


        private string fAdInfo;
        [Size(256)]
        public string AdInfo
        {
            get { return fAdInfo; }
            set { SetPropertyValue(nameof(AdInfo), ref fAdInfo, value); }
        }


        private ApplicationUser fStaff;
        [Association("Analize-Staff")]
        public ApplicationUser Staff
        {
            get { return fStaff; }
            set { SetPropertyValue(nameof(Staff), ref fStaff, value); }
        }

        private spOrganization fOrganization;
        [Association("Analize-Organization")]
        public spOrganization Organization
        {
            get { return fOrganization; }
            set { SetPropertyValue(nameof(Organization), ref fOrganization, value); }
        }

    }
}
