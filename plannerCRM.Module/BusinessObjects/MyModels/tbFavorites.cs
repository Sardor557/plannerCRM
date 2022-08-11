using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.tbFavorites")]
    public class tbFavorites : BaseModel
    {
        public tbFavorites(Session session) : base(session)
        {
        }


        private tbUser fUser;
        public tbUser User
        {
            get { return fUser; }
            set { SetPropertyValue(nameof(User), ref fUser, value); }
        }


        private long fTelegramId;
        public long TelegramId
        {
            get { return fTelegramId; }
            set { SetPropertyValue(nameof(TelegramId), ref fTelegramId, value); }
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
    }
}
