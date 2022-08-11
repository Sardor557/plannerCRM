using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.tbScheduler")]
    public class tbScheduler : BaseModel
    {
        public tbScheduler(Session session) : base(session)
        {
        }

        private tbUser fUser;
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


        private DateTime fAppointmentDateTime;
        public DateTime AppointmentDateTime
        {
            get { return fAppointmentDateTime; }
            set { SetPropertyValue(nameof(fAppointmentDateTime), ref fAppointmentDateTime, value); }
        }

        
        private string fAdInfo;
        [Size(200)]
        public string AdInfo
        {
            get { return fAdInfo; }
            set { SetPropertyValue(nameof(AdInfo), ref fAdInfo, value); }
        }


        private spCategory fCategory;
        public spCategory Category
        {
            get { return fCategory; }
            set { SetPropertyValue(nameof(Category), ref fCategory, value); }
        }



        private spOrganization fOrganization;
        public spOrganization Organization
        {
            get { return fOrganization; }
            set { SetPropertyValue(nameof(Organization), ref fOrganization, value); }
        }
    }
}
