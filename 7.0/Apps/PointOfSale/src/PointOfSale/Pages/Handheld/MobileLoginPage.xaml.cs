

namespace PointOfSale.Pages.Handheld;

public partial class MobileLoginPage : ContentPage
{
	public MobileLoginPage()
	{
		InitializeComponent();
	}

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        base.OnNavigatedTo(args);
    }
}
