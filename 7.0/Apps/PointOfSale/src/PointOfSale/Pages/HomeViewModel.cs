using System;
using PointOfSale.Messages;

namespace PointOfSale.Pages;

[INotifyPropertyChanged]
public partial class HomeViewModel
{
    [ObservableProperty]
    ObservableCollection<Item> _products;

    [ObservableProperty]
    string category = ItemCategory.Main.ToString();

    partial void OnCategoryChanged(string cat)
    {
       ItemCategory category = (ItemCategory)Enum.Parse(typeof(ItemCategory), cat);
       _products = new ObservableCollection<Item>(
           AppData.Items.Where(x => x.Category == category).ToList()
       );
       OnPropertyChanged(nameof(Products));
    }

    public HomeViewModel()
    {
        _products = new ObservableCollection<Item>(
            AppData.Items.Where(x=>x.Category == ItemCategory.Main).ToList()
        );
    }

    [RelayCommand]
    async Task Preferences()
    {
        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}?sub=appearance");
    }

    #pragma warning disable 1998, 618
    [RelayCommand]
    async Task AddProduct()
    {
        WeakReferenceMessenger.Default.Send<AddProductMessage>(new AddProductMessage(true));
    }
    #pragma warning restore 1998, 618
}