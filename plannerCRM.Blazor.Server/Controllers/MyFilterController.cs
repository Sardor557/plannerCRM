//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Actions;
//using DevExpress.ExpressApp.SystemModule;
//using DevExpress.Persistent.Base;
//using plannerCRM.Module.BusinessObjects.MyModels;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Text;

//namespace plannerCRM.Blazor.Server.Controllers
//{
//    public partial class MyFilterController : ViewController
//    {
//        public MyFilterController()
//        {
//            InitializeComponent();
//            RegisterActions(components);
//            TargetObjectType = typeof(spCategory);
//        }

//        private void MyFilterController_Activated(object sender, EventArgs e)
//        {
//            FilterController standardFilterController = Frame.GetController<FilterController>();
//            if (standardFilterController != null)
//            {
//                standardFilterController.CustomGetFullTextSearchProperties += new EventHandler<CustomGetFullTextSearchPropertiesEventArgs>(standardFilterController_CustomGetFullTextSearchProperties);
//            }
//        }

//        void standardFilterController_CustomGetFullTextSearchProperties(object sender, CustomGetFullTextSearchPropertiesEventArgs e)
//        {
//            foreach (string property in GetFullTextSearchProperties())
//            {
//                e.Properties.Add(property);
//            }
//            e.Handled = true;
//        }
//        private List<string> GetFullTextSearchProperties()
//        {
//            List<string> searchProperties = new List<string>();
//            searchProperties.Add("NameUz");
//            return searchProperties;
//        }
//    }
//}
