using System;
using DevExpress.ExpressApp.Blazor.Components.Models;

namespace plannerCRM.Blazor.Server.Editors
{
    public class ButtonModel : ComponentModelBase
    {
        public event EventHandler Click;

        public string Text
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }
        public void ClickFromUI()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}