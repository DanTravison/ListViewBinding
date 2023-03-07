using ListViewBinding.ViewModels;

namespace ListViewBinding;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		BindingContext = new ColorsViewModel();
		InitializeComponent();
	}
}

