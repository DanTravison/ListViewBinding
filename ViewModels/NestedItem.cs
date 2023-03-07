using System.Collections.ObjectModel;

namespace ListViewBinding.ViewModels
{
    public class NestedItem : ReadOnlyObservableCollection<NamedColor>
    {
        public NestedItem(ObservableCollection<NamedColor> colors)
            : base(colors)
        {
        }
    }
}
