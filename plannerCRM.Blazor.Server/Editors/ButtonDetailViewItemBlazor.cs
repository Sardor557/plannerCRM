using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using plannerCRM.Module.BusinessObjects.MyModels;

namespace plannerCRM.Blazor.Server.Editors
{
    public interface IModelButtonDetailViewItemBlazor : IModelViewItem { }

    [ViewItem(typeof(IModelButtonDetailViewItemBlazor))]
    public class ButtonDetailViewItemBlazor : ViewItem, IComplexViewItem
    {
        private IObjectSpace objectSpace;
        private XafApplication application;

        public class ButtonHolder : IComponentContentHolder
        {
            public ButtonModel ComponentModel { get; }

            public ButtonHolder(ButtonModel componentModel)
            {
                ComponentModel = componentModel;
            }

            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, ButtonRenderer.Create(ComponentModel));
        }

        public ButtonDetailViewItemBlazor(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }

        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
            this.objectSpace = objectSpace;
        }

        protected override object CreateControlCore()
        {
            return new ButtonHolder(new ButtonModel());
        }

        protected override void OnControlCreated()
        {
            if (Control is ButtonHolder holder)
            {
                holder.ComponentModel.Text = "Кнопка!";
                holder.ComponentModel.Click += ComponentModel_Click;
            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (Control is ButtonHolder holder)
            {
                holder.ComponentModel.Click -= ComponentModel_Click;
            }
            base.BreakLinksToControl(unwireEventsOnly);
        }
        private void ComponentModel_Click(object sender, EventArgs e)
        {
            var a = application;
            var cur = CurrentObject;
            if (cur is SearchFilter search)
            {
                search.IsActive = true;
            }
            //else if (cur is spOrganization organization)
            //{
            //    organization.Name = null;
            //    organization.ChatId = null;
            //    organization.IsActive = false;
            //}

            application.ShowViewStrategy.ShowMessage("Action is executed!");

        }
    }
}