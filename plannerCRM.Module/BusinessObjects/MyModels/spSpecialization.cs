using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.spSpecialization")]
    public class spSpecialization : BaseModel
    {
        public spSpecialization(Session session) : base(session)
        {
        }


        private string fNameUz;
        [Size(200)]
        [Indexed(Unique = true)]
        public string NameUz
        {
            get { return fNameUz; }
            set { SetPropertyValue(nameof(NameUz), ref fNameUz, value); }
        }


        private string fNameLt;
        [Size(200)]
        [Indexed(Unique = true)]
        public string NameLt
        {
            get { return fNameLt; }
            set { SetPropertyValue(nameof(NameLt), ref fNameLt, value); }
        }


        private string fNameRu;
        [Size(200)]
        [Indexed(Unique = true)]
        public string NameRu
        {
            get { return fNameRu; }
            set { SetPropertyValue(nameof(NameRu), ref fNameRu, value); }
        }


        private string fPhotoPath;
        public string PhotoPath
        {
            get { return fPhotoPath; }
            set { SetPropertyValue(nameof(PhotoPath), ref fPhotoPath, value); }
        }

        [Association("Specialization-Organization")]
        public XPCollection<spOrganization> spOrganizations
        {
            get
            {
                return GetCollection<spOrganization>(nameof(spOrganizations));
            }
        }
    }
}
