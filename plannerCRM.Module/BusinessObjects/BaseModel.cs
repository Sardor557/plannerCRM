using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System.ComponentModel;

namespace plannerCRM.Module.BusinessObjects
{
    [NonPersistent]
    public abstract class BaseModel : XPLiteObject
    {
        protected BaseModel(Session session) : base(session)
        {
        }

        private int _Id;
        [Appearance("1", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return _Id; }
            set { SetPropertyValue(nameof(Id), ref _Id, value); }
        }

        [Appearance("2", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public string Created => $"{CreatedBy} ({CreatedOn:dd.MM.yyyy HH:mm:ss})";

        [Appearance("3", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public string Modified => $"{ModifiedBy} ({ModifiedOn:dd.MM.yyyy HH:mm:ss})";

        [Browsable(false)]
        [Nullable(false)]
        [Appearance("4", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public DateTime? CreatedOn { get; set; }

        [Browsable(false)]
        [Appearance("5", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public DateTime? ModifiedOn { get; set; }

        [Browsable(false)]
        [Size(100)]
        [Nullable(false)]
        [Appearance("6", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public string CreatedBy { get; set; }

        [Browsable(false)]
        [Size(100)]
        [Appearance("7", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public string ModifiedBy { get; set; }

        private bool _IsActive;
        [Indexed, Nullable(false)]
        [ColumnDefaultValue(true)]
        public bool IsActive
        {
            get { return _IsActive; }
            set { SetPropertyValue(nameof(IsActive), ref _IsActive, value); }
        }

        protected override void OnSaving()
        {
            var owner = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
            if (owner != null)
            {
                DateTime serverTime =
                    (DateTime)Session.Evaluate(
                        typeof(XPObjectType), CriteriaOperator.Parse("Now()"), null);
                if (!CreatedOn.HasValue)
                {
                    CreatedOn = serverTime;
                    CreatedBy = owner.UserName;
                }
                else
                {
                    ModifiedOn = serverTime;
                    ModifiedBy = owner.UserName;
                }
            }

            base.OnSaving();
        }
    }
}
