using AppWishList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppWishlist.Messages;
using MauiAppWishlist.Repositories;
using MauiAppWishlist.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isLoading;

        private IProductRepositories _repository;

        [ObservableProperty]
        private ObservableCollection<Product> products;
       
        public MainPageViewModel()
        {
            _repository = new ProductRepositories();

            MessengerHelper.ReloadDataRequested += OnReloadData;
            LoadData();
        }

        [RelayCommand]
        private void GoToAddPage()
        {
            var addProductPageViewModel = new AddProductPageViewModel(this);
            var addProductPage = new AddProductPage
            {
                BindingContext = addProductPageViewModel
            };

            Shell.Current.Navigation.PushAsync(addProductPage);
        }
        private IList<Product> _products;
        public void LoadData()
        {
            _products = _repository.GetAll().ToList();
            Products = new ObservableCollection<Product>(_products);  
        }
        private void OnReloadData(ReloadDataMessage message)
        {
            LoadData();
        }
        [RelayCommand]
        private void DeleteProduct(Product product)
        {
            _repository.Delete(product);
            LoadData();
        }
        [RelayCommand]
        private void GoToDetail(Product product)
        {
            var navigationParameter = new Dictionary<string, object>()
            {
                {"product", product},
            };
             Shell.Current.GoToAsync("detail", navigationParameter);
        }

        [RelayCommand]
        private void Teste()
        {
            IsLoading = true;
        }
    }
}
