//using DevExpress.Data.Filtering;
//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Actions;
//using DevExpress.ExpressApp.Editors;
//using DevExpress.ExpressApp.Layout;
//using DevExpress.ExpressApp.Model;
//using DevExpress.ExpressApp.Model.NodeGenerators;
//using DevExpress.ExpressApp.SystemModule;
//using DevExpress.ExpressApp.Templates;
//using DevExpress.ExpressApp.Utils;
//using DevExpress.Persistent.Base;
//using DevExpress.Persistent.Validation;
//using plannerCRM.Module.BusinessObjects.MyModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace plannerCRM.Blazor.Server.Controllers.SearchController
//{
//    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
//    public partial class SearchFilterController : ViewController
//    {
//        // Use CodeRush to create Controllers and Actions with a few keystrokes.
//        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
//        public SearchFilterController()
//        {
//            TargetViewType = ViewType.ListView;
//            TargetObjectType = typeof(SearchFilter);
//            Activated += SearchFilterController_Activated;
//            ViewControlsCreated += SearchFilterController_ViewControlsCreated;

//            InitializeComponent();
//            // Target required Views (via the TargetXXX properties) and create their Actions.
//        }

//        private void SearchFilterController_Activated(object sender, EventArgs e)
//        {
//            ListEditor listEditor = ((ListView)View).Editor;
//            IObjectSpace objectSpace = View.ObjectSpace;

//            var searchfilter = new SearchFilter();
//            var categories = objectSpace.GetObjects<spCategory>();
//            searchfilter.Categories = categories;
//            foreach (var item in categories)
//            {
//                searchfilter.Category = item;
//            }

//            Application.CreateListView(typeof(SearchFilter), true);
//            listEditor.CreateControls();

//        }

//        private void SearchFilterController_ViewControlsCreated(object sender, EventArgs e)
//        {
//            var objectType = typeof(SearchFilter);
//            ListEditor listEditor = ((ListView)View).Editor;
//            IObjectSpace objectSpace = View.ObjectSpace;
//            IObjectSpace newObjectSpace = Application.CreateObjectSpace(objectType);
//            string listViewId = Application.FindLookupListViewId(objectType);
//            IModelListView modelListView = (IModelListView)Application.FindModelView(listViewId);
//            CollectionSourceBase collectionSource = Application.CreateCollectionSource(newObjectSpace, objectType, listViewId);

//            var searchfilter = new SearchFilter();
//            var categories = objectSpace.GetObjects<spCategory>();
//            searchfilter.Categories = categories;
//            foreach (var item in categories)
//            {
//                searchfilter.Category = item;
//            }
//            listEditor.DataSource = searchfilter;
//            Application.CreateListView(modelListView, collectionSource, true, listEditor);


//        }

//        protected override void OnActivated()
//        {
//            base.OnActivated();


//            // Perform various tasks depending on the target View.
//        }

//        protected override void OnViewControlsCreated()
//        {
//            //Application.ObjectSpaceCreated += Application_ObjectSpaceCreated;
//            base.OnViewControlsCreated();
//            // Access and customize the target View control.
//        }

//        protected override void OnDeactivated()
//        {

//            base.OnDeactivated();
//        }
//        //private void ObjectSpace_ObjectGetting(object sender, ObjectGettingEventArgs e)
//        //{
//        //    var objectSpace = (IObjectSpace)sender;
//        //    if (e.SourceObject is SearchFilter)
//        //    {
//        //        var sourceObject = (SearchFilter)e.SourceObject;
//        //        var targetObject = new SearchFilter();
//        //        targetObject.Category = objectSpace.GetObject<spCategory>(sourceObject.Category);
//        //        var categories = new List<spCategory>();
//        //        foreach (var cat in sourceObject.Categories)
//        //        {
//        //            categories.Add(objectSpace.GetObject<spCategory>(cat));
//        //        }
//        //        targetObject.Categories = categories;
//        //        e.TargetObject = targetObject;
//        //    }
//        //}

//        //private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
//        //{
//        //    CompositeObjectSpace compositeObjectSpace = e.ObjectSpace as CompositeObjectSpace;
//        //    if (compositeObjectSpace != null)
//        //    {
//        //        if (!(compositeObjectSpace.Owner is CompositeObjectSpace))
//        //        {
//        //            compositeObjectSpace.PopulateAdditionalObjectSpaces((XafApplication)sender);
//        //        }
//        //    }
//        //    NonPersistentObjectSpace nonPersistentObjectSpace = e.ObjectSpace as NonPersistentObjectSpace;
//        //    if (nonPersistentObjectSpace != null)
//        //    {
//        //        nonPersistentObjectSpace.AutoRefreshAdditionalObjectSpaces = true;
//        //        nonPersistentObjectSpace.ObjectGetting += ObjectSpace_ObjectGetting;
//        //    }
//        //}

//    }
//}
