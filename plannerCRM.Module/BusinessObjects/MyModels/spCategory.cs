using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.spCategory")]
    [Appearance("ConiditionView", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "IsActive = false",
        Context = "Any", BackColor = "Red", FontColor = "Maroon", Priority = 1)]
    public class spCategory : BaseModel
    {
        public spCategory(Session session) : base(session)
        {
        }


        private string fNameUz;
        [Size(200)]
        public string NameUz
        {
            get { return fNameUz; }
            set { SetPropertyValue(nameof(NameUz), ref fNameUz, value); }
        }


        private string fNameLt;
        [Size(200)]
        public string NameLt
        {
            get { return fNameLt; }
            set { SetPropertyValue(nameof(NameLt), ref fNameLt, value); }
        }


        private string fNameRu;
        [Size(200)]
        public string NameRu
        {
            get { return fNameRu; }
            set { SetPropertyValue(nameof(NameRu), ref fNameRu, value); }
        }


        private spOrganization fOrganization;
        [Appearance("ConiditionOrgItemView", AppearanceItemType = "Action", TargetItems = "Organization.Deactivate", Criteria = "Organization.IsActive = false",
        Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public spOrganization Organization
        {
            get { return fOrganization; }
            set { SetPropertyValue(nameof(Organization), ref fOrganization, value); }
        }
    }
}
