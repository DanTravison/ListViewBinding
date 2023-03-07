using System.Collections.ObjectModel;

namespace ListViewBinding.ViewModels
{
    public sealed class ColorsViewModel
    {
        public ColorsViewModel() 
        {
            ObservableCollection<NamedColor> colors = new(NamedColor.Colors);
            Colors = new(colors);
            Nested = new NestedViewModel();
        }

        public ReadOnlyObservableCollection<NamedColor> Colors
        {
            get;
        }

        public NestedViewModel Nested
        {
            get;
        }
    }
}
