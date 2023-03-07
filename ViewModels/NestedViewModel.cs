using System.Collections.ObjectModel;

namespace ListViewBinding.ViewModels
{
    public sealed class NestedViewModel
    {
        public NestedViewModel()
        {
            ObservableCollection<NestedItem> items = new();
            ObservableCollection<NamedColor> colors = new();

            foreach (NamedColor color in NamedColor.Colors)
            {
                colors.Add(color);
                if (colors.Count == 5)
                {
                    items.Add(new NestedItem(colors));
                    colors = new();
                }
            }
            if (colors.Count > 0)
            {
                items.Add(new NestedItem(colors));
            }
            Colors = new(items);
        }

        public ReadOnlyObservableCollection<NestedItem> Colors
        {
            get;
        }
    }
}
