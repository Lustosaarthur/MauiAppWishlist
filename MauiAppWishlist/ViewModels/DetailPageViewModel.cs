using AppWishList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.ViewModels
{
    [QueryProperty(nameof(Product), "product")]
    public partial class DetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Product product;

        [RelayCommand]
        private void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }

    }
}
