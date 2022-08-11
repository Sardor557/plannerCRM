using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.tbUser")]

    public class tbUser : BaseModel
    {
        public tbUser(Session session) : base(session)
        {
        }


        private string fSurname;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(100)]
        public string Surname
        {
            get { return fSurname; }
            set { SetPropertyValue(nameof(Surname), ref fSurname, value); }
        }


        private string fName;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(100)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue(nameof(Name), ref fName, value); }
        }


        private string fPatronymic;
        [Size(100)]
        public string Patronymic
        {
            get { return fPatronymic; }
            set { SetPropertyValue(nameof(Patronymic), ref fPatronymic, value); }
        }


        private string fGender;
        [Size(20)]
        public string Gender
        {
            get { return fGender; }
            set { SetPropertyValue(nameof(Gender), ref fGender, value); }
        }


        private DateTime? fBirthDay;
        public DateTime? BirthDay
        {
            get { return fBirthDay; }
            set { SetPropertyValue(nameof(BirthDay), ref fBirthDay, value); }
        }


        private string fPhoneNum;
        [Indexed]
        [Size(20)]
        public string PhoneNum
        {
            get { return fPhoneNum; }
            set { SetPropertyValue(nameof(PhoneNum), ref fPhoneNum, value); }
        }


        private long? fTelegramId;
        public long? TelegramId
        {
            get { return fTelegramId; }
            set { SetPropertyValue(nameof(TelegramId), ref fTelegramId, value); }
        }


        private string fPhotoUrl;
        [Size(256)]
        public string PhotoUrl
        {
            get { return fPhotoUrl; }
            set { SetPropertyValue(nameof(PhotoUrl), ref fPhotoUrl, value); }
        }

        [Association("Analize-User")]
        public XPCollection<tbAnalizeResult> tbAnalizeResults
        {
            get
            {
                return GetCollection<tbAnalizeResult>(nameof(tbAnalizeResults));
            }
        }
    }
}
