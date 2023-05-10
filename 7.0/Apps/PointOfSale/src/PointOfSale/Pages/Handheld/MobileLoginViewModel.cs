
namespace PointOfSale.Pages.Handheld;

[INotifyPropertyChanged]
public partial class MobileLoginViewModel
{
    [RelayCommand]
    async Task Login()
    {
        await Shell.Current.GoToAsync("//orders");
    }

    // display the message
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    private async Task ShowMessage(string title, string message)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _ = App.Current.MainPage.Dispatcher.Dispatch(async () =>
        {
            await App.Current.MainPage.DisplayAlert(title, message, "OK").ConfigureAwait(false);
        });
    }
}