using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using plannerCRM.Module.BusinessObjects.MyModels;

namespace plannerCRM.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SimpleActionController : ViewController
    {
        private SimpleAction ModelActivation;
        DeleteObjectsViewController DeleteController;
        private const string Key = "Deactivation in code";
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/

        public SimpleActionController()
        {
            TargetViewType = ViewType.ListView;
            TargetObjectType = typeof(spCategory);
            ModelActivation = new SimpleAction(this, "Searching", DevExpress.Persistent.Base.PredefinedCategory.Search);
            ModelActivation.ToolTip = "Set activation to false or true";
            ModelActivation.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            ModelActivation.Execute += ModelAction_Execute;
            InitializeComponent();
        }

        private void ModelAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedObjects = View.SelectedObjects;
            var app = Application;
            var ev = Events;
            var fr = Frame;
            var s = Site;



            //foreach (SearchFilter cat in selectedObjects)
            //{
            //    if (!cat.IsActive)
            //        cat.IsActive = true;
            //    else
            //        cat.IsActive = false;

            //    cat.Session.CommitTransaction();
            //    Application.ShowViewStrategy.ShowMessage($"categories has changed activation", InformationType.Info);
            //}
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            //DeleteController =
            //    Frame.GetController<DeleteObjectsViewController>();

            //if (DeleteController != null)
            //{
            //    DeleteController.Active[Key] = false;
            //}
        }

        protected override void OnDeactivated()
        {
            //if (DeleteController != null)
            //{
            //    DeleteController.Active.RemoveItem(Key);
            //    DeleteController = null;
            //}
            base.OnDeactivated();
        }
    }
}
