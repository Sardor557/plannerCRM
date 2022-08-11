using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [DomainComponent, DefaultClassOptions]
    public class SearchFilter : NonPersistentBaseObject, IObjectSpaceLink
    {
        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }


        private spCategory category;
        public spCategory Category
        {
            get
            {
                if (category == null)
                {
                    category = ObjectSpace.GetObjects<spCategory>(CriteriaOperator.Parse($"CreatedOn>='{CreatedAt}'")).FirstOrDefault();
                }
                return category;
            }
            set { category = value; }
        }

        private IObjectSpace objectSpace;
        [Browsable(false)]
        public IObjectSpace ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }

        private IList<spCategory> categories;
        public IList<spCategory> Categories
        {
            get
            {
                //if (categories == null)
                //    categories = ObjectSpace.GetObjects<spCategory>(CriteriaOperator.Parse($"CreatedOn>='{CreatedAt}'"));

                return categories;
            }
            set { categories = value; }
        }
    }
}
