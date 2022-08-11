using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.tbRating")]
    public class tbRating : BaseModel
    {
        public tbRating(Session session) : base(session)
        {
        }


        private tbUser fUser;
        [RuleRequiredField(DefaultContexts.Save)]
        public tbUser User
        {
            get { return fUser; }
            set { SetPropertyValue(nameof(User), ref fUser, value); }
        }


        private ApplicationUser fStaff;
        public ApplicationUser Staff
        {
            get { return fStaff; }
            set { SetPropertyValue(nameof(Staff), ref fStaff, value); }
        }


        private spOrganization fOrganization;
        public spOrganization Organization
        {
            get { return fOrganization; }
            set { SetPropertyValue(nameof(Organization), ref fOrganization, value); }
        }


        private int fRating;
        public int Rating
        {
            get { return fRating; }
            set { SetPropertyValue(nameof(Rating), ref fRating, value); }
        }


        private string fComment;
        public string Comment
        {
            get { return fComment; }
            set { SetPropertyValue(nameof(Comment), ref fComment, value); }
        }
    }
}
