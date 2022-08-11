using DevExpress.ExpressApp.Blazor.Components.Models;
using plannerCRM.Module.BusinessObjects.MyModels;

namespace plannerCRM.Blazor.Server.Editors.ListEditors
{
    public class CategoryItemListViewModel : ComponentModelBase
    {
        public event EventHandler<CategoryItemClickEventArgs> ItemClick;
        public SearchFilter Data
        {
            get => GetPropertyValue<SearchFilter>();
            set => SetPropertyValue(value);
        }

        public void Refresh() => RaiseChanged();

        public void OnItemClick(SearchFilter item) => ItemClick?.Invoke(this, new CategoryItemClickEventArgs(item));
    }

    public class CategoryItemClickEventArgs : EventArgs
    {
        public SearchFilter Item { get; }
        public CategoryItemClickEventArgs(SearchFilter item)
        {
            Item = item;
        }
    }
}

