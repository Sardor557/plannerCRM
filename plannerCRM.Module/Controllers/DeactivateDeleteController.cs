using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication1.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    //public partial class DeactivateDeleteController : ObjectViewController
    //{
    //    private const string Key = "Deactivation in code";
    //    DeleteObjectsViewController DeleteController;

    //    public DeactivateDeleteController()
    //    {
    //        InitializeComponent();
    //        // Target required Views (via the TargetXXX properties) and create their Actions.
    //    }
    //    protected override void OnActivated()
    //    {
    //        base.OnActivated();
    //        DeleteController = Frame.GetController<DeleteObjectsViewController>();

    //        if (DeleteController != null)
    //        {
    //            DeleteController.Active[Key] = false;
    //        }
    //    }
    //    protected override void OnViewControlsCreated()
    //    {
    //        base.OnViewControlsCreated();
    //        // Access and customize the target View control.
    //    }
    //    protected override void OnDeactivated()
    //    {
    //        if (DeleteController != null)
    //        {
    //            DeleteController.Active.RemoveItem(Key);
    //            DeleteController = null;
    //        }
    //        base.OnDeactivated();
    //    }
    //}
}
