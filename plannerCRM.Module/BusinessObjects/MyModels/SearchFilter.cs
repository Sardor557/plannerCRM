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
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now.AddDays(1);

        public bool IsActive { get; set; }


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
                categories = ObjectSpace.GetObjects<spCategory>()
                    .Where(x => x.CreatedOn >= Start && x.CreatedOn <= End && x.IsActive == IsActive)
                    .ToList();

                return categories;
            }
            set { categories = value; }
        }
    }
}
