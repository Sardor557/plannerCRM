//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Actions;
//using plannerCRM.Module.BusinessObjects.MyModels;

//namespace plannerCRM.Blazor.Server.Controllers
//{
//    public class ProcessCategoryListViewRowController : ObjectViewController<ObjectView, spCategory>
//    {
//        public ProcessCategoryListViewRowController()
//        {
//            //TargetViewId = "spCategory_LookupListView";
//            var popupAction = new PopupWindowShowAction(this, "ShowPopup", DevExpress.Persistent.Base.PredefinedCategory.View);
//            //popupAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
//            popupAction.CustomizePopupWindowParams += PopupAction_CustomizePopupWindowParams;
//        }

//        private void PopupAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
//        {
//            var objects = (spCategory)View.CurrentObject;
//            objects.IsActive = true;
//            objects.NameRu = "categorss";
//            objects.Session.CommitTransaction();

//            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(spCategory));
//            string categoryListViewId = Application.FindListViewId(typeof(spCategory));
//            CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(spCategory), categoryListViewId);
//            e.View = e.Application.CreateListView(categoryListViewId, collectionSource, false);
//            //e.Maximized = false;
//        }
//    }
//}
