using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using plannerCRM.Module.BusinessObjects.MyModels;
using System.ComponentModel;

namespace plannerCRM.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class plannerCRMModule : ModuleBase
{
    public plannerCRMModule()
    {
        // 
        // plannerCRMModule
        // 
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileData));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileAttachmentBase));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }

    public override void Setup(XafApplication application)
    {
        base.Setup(application);
        //application.ObjectSpaceCreated += Application_CategorySearchObjectSpaceCreated;
        //application.SetupComplete += Application_SetupComplete;
        application.ObjectSpaceCreated += Application_ObjectSpaceCreated;

        // Manage various aspects of the application UI and behavior at the module level.
    }

    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }

    private void Application_CategorySearchObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
    {
        CompositeObjectSpace compositeObjectSpace = e.ObjectSpace as CompositeObjectSpace;
        if (compositeObjectSpace != null)
        {
            if (!(compositeObjectSpace.Owner is CompositeObjectSpace))
            {
                compositeObjectSpace.PopulateAdditionalObjectSpaces((XafApplication)sender);
            }
        }
        NonPersistentObjectSpace nonPersistentObjectSpace = e.ObjectSpace as NonPersistentObjectSpace;
        if (nonPersistentObjectSpace != null)
        {
            nonPersistentObjectSpace.AutoRefreshAdditionalObjectSpaces = true;
            nonPersistentObjectSpace.ObjectGetting += ObjectSpace_CategorySearchGetting;
        }
    }

    private void ObjectSpace_CategorySearchGetting(object sender, ObjectGettingEventArgs e)
    {
        var objectSpace = (IObjectSpace)sender;
        if (e.SourceObject is SearchFilter)
        {
            var sourceObject = (SearchFilter)e.SourceObject;
            var targetObject = new SearchFilter();
            //targetObject.Category = objectSpace.GetObject<spCategory>(sourceObject.Category);
            var categories = new List<spCategory>();
            foreach (var cat in sourceObject.Categories)
            {
                categories.Add(objectSpace.GetObject<spCategory>(cat));
            }
            targetObject.Categories = categories;
            e.TargetObject = targetObject;
        }
    }

    private void Application_SetupComplete(object sender, EventArgs e)
    {
        Application.ObjectSpaceCreated += Application_ObjectSpaceCreated;
    }

    private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
    {
        var nonPersistentObjectSpace = e.ObjectSpace as NonPersistentObjectSpace;
        if (nonPersistentObjectSpace != null)
        {
            nonPersistentObjectSpace.ObjectsGetting += ObjectSpace_ObjectsGetting;
        }

        CompositeObjectSpace compositeObjectSpace = e.ObjectSpace as CompositeObjectSpace;
        if (compositeObjectSpace != null)
        {
            if (!(compositeObjectSpace.Owner is CompositeObjectSpace))
            {
                compositeObjectSpace.PopulateAdditionalObjectSpaces((XafApplication)sender);
            }
        }
    }

    private void ObjectSpace_ObjectsGetting(object sender, ObjectsGettingEventArgs e)
    {
        var objectSpace = (IObjectSpace)sender;
        if (e.ObjectType == typeof(SearchFilter))
        {
            BindingList<SearchFilter> objects = new BindingList<SearchFilter>();


            var sourceObject = (SearchFilter)e.Objects;
            var targetObject = new SearchFilter();

            for (int i = 1; i < 10; i++)
            {
                objects.Add(new SearchFilter() { Start = new DateTime(2022, 01, 01) });
            }
            e.Objects = objects;
        }
    }
}
