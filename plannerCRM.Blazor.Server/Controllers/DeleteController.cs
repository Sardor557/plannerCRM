//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.SystemModule;
//using plannerCRM.Module.BusinessObjects.MyModels;

//namespace plannerCRM.Blazor.Server.Controllers
//{
//    public class DeleteControllerAction : ViewController
//    {
//        private string defaultMessage;
//        private DeleteObjectsViewController DeleteObjectController;

//        public DeleteControllerAction()
//        {
//            TargetObjectType = typeof(spCategory);
//        }

//        protected override void OnActivated()
//        {
//            base.OnActivated();
//            DeleteObjectController = Frame.GetController<DeleteObjectsViewController>();
//            if (DeleteObjectController != null)
//            {
//                defaultMessage = DeleteObjectController.DeleteAction.GetFormattedConfirmationMessage();
//                DeleteObjectController.
//                View.SelectionChanged += View_SelectionChanged;
//                UpdateConfirmationMessage();
//            }
//        }

//        private void View_SelectionChanged(object sender, EventArgs e)
//        {
//            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(spCategory));
//            UpdateConfirmationMessage();
//        }

//        private void UpdateConfirmationMessage()
//        {
//            if (View.SelectedObjects.Count == 1)
//            {
//                DeleteObjectController.DeleteAction.ConfirmationMessage =
//                    string.Format("You are about to delete the '{0}' category. Do you want to proceed?",
//                    ((spCategory)View.CurrentObject).NameUz);

//            }
//            else
//            {
//                DeleteObjectController.DeleteAction.ConfirmationMessage =
//                    string.Format("You are about to delete {0} category. Do you want to proceed?",
//                    View.SelectedObjects.Count);
//            }
//        }

//        protected override void OnDeactivated()
//        {
//            base.OnDeactivated();
//            if (DeleteObjectController != null)
//            {
//                View.SelectionChanged -= View_SelectionChanged;
//                DeleteObjectController.DeleteAction.ConfirmationMessage = defaultMessage;
//                DeleteObjectController = null;
//            }
//        }
//    }
//}
