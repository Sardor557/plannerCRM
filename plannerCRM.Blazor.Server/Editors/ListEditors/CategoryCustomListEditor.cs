using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using plannerCRM.Module.BusinessObjects.MyModels;
using System.Collections;
using System.ComponentModel;

namespace plannerCRM.Blazor.Server.Editors.ListEditors
{
    [ListEditor(typeof(spCategory))]
    public class CategoryCustomListEditor : ListEditor, IComplexListEditor
    {
        private CollectionSourceBase collectionSource;
        private XafApplication application;

        public CategoryCustomListEditor(IModelListView model) : base(model) { }

        public override SelectionType SelectionType => SelectionType.Full;

        public void Setup(CollectionSourceBase collectionSource, XafApplication application)
        {
            this.collectionSource = collectionSource;
            this.application = application;
        }

        //public override IList GetSelectedObjects()
        //{
        //    //var objectType = typeof(SearchFilter);
        //    //IObjectSpace newObjectSpace = application.CreateObjectSpace(objectType);

        //    //var searchfilter = new SearchFilter();
        //    //var categories = newObjectSpace.GetObjects<spCategory>();
        //    //searchfilter.Categories = categories;
        //    //foreach (var item in categories)
        //    //{
        //    //    searchfilter.Category = item;
        //    //}
        //    //return searchfilter.Categories.ToArray();
        //    return new List<spOrganization>();
        //}

        //public override void Refresh()
        //{
        //    throw new NotImplementedException();
        //}


        //protected override void AssignDataSourceToControl(object dataSource)
        //{
        //    if (dataSource is QueryableCollection query)
        //    {
        //        if (query.Queryable is DevExpress.Xpo.XPQuery<spCategory> categories)
        //        {
        //            var objectType = typeof(SearchFilter);
        //            var searchfilter = new SearchFilter();
        //            IObjectSpace newObjectSpace = application.CreateObjectSpace(objectType);

        //            searchfilter.Categories = categories.ToList();
        //            foreach (var item in categories)
        //            {
        //                searchfilter.Category = item;
        //            }
        //            collectionSource.Add(searchfilter);
        //            collectionSource.Add(categories);
        //        }
        //    }
        //}

        //protected override object CreateControlsCore()
        //{
        //    return 0;
        //}

        public class CategoryFilterListViewHolder : IComponentContentHolder
        {
            private RenderFragment componentContent;
            public CategoryFilterListViewHolder(CategoryItemListViewModel componentModel)
            {
                ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            }
            private RenderFragment CreateComponent() => ComponentModelObserver.Create(ComponentModel, CategoryItemListViewRenderer.Create(ComponentModel));
            public CategoryItemListViewModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => componentContent ??= CreateComponent();
        }

        private SearchFilter selectedObjects = new SearchFilter();

        protected override object CreateControlsCore() => new CategoryFilterListViewHolder(new CategoryItemListViewModel());

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (Control is CategoryFilterListViewHolder holder)
            {
                if (holder.ComponentModel.Data is IBindingList bindingList)
                {
                    bindingList.ListChanged -= BindingList_ListChanged;
                }
                var objectType = typeof(SearchFilter);
                IObjectSpace newObjectSpace = application.CreateObjectSpace(objectType);

                var searchfilter = new SearchFilter();
                var categories = newObjectSpace.GetObjects<spCategory>();
                searchfilter.Categories = categories;
                foreach (var item in categories)
                {
                    searchfilter.Category = item;
                }

                holder.ComponentModel.Data = searchfilter;

                if (dataSource is IBindingList newBindingList)
                {
                    newBindingList.ListChanged += BindingList_ListChanged;
                }
            }
        }

        protected override void OnControlsCreated()
        {
            if (Control is CategoryFilterListViewHolder holder)
            {
                holder.ComponentModel.ItemClick += ComponentModel_ItemClick;
            }
            base.OnControlsCreated();
        }

        public override void BreakLinksToControls()
        {
            if (Control is CategoryFilterListViewHolder holder)
            {
                holder.ComponentModel.ItemClick -= ComponentModel_ItemClick;
            }
            AssignDataSourceToControl(null);
            base.BreakLinksToControls();
        }

        public override void Refresh()
        {
            if (Control is CategoryFilterListViewHolder holder)
            {
                holder.ComponentModel.Refresh();
            }
        }

        private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            Refresh();
        }

        private void ComponentModel_ItemClick(object sender, CategoryItemClickEventArgs e)
        {
            var objectType = typeof(SearchFilter);
            IObjectSpace newObjectSpace = application.CreateObjectSpace(objectType);

            var searchfilter = new SearchFilter();
            var categories = newObjectSpace.GetObjects<spCategory>();
            searchfilter.Categories = categories;
            foreach (var item in categories)
            {
                searchfilter.Category = item;
            }

            selectedObjects = searchfilter;
            OnSelectionChanged();
            OnProcessSelectedItem();
        }

        //public override SelectionType SelectionType => SelectionType.Full;
        public override IList GetSelectedObjects()
        {
            var objectType = typeof(SearchFilter);
            IObjectSpace newObjectSpace = application.CreateObjectSpace(objectType);

            var searchfilter = new SearchFilter();
            var categories = newObjectSpace.GetObjects<spCategory>();
            searchfilter.Categories = categories;
            foreach (var item in categories)
            {
                searchfilter.Category = item;
            }

            selectedObjects = searchfilter;
            return selectedObjects.Categories.ToList();
        }
    }
}
