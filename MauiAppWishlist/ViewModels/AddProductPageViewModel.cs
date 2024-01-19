using AppWishList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppWishlist.Messages;
using MauiAppWishlist.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.ViewModels
{
    public partial class AddProductPageViewModel : ObservableObject
    {
        private readonly WebScrapingService _webScrapingService;

        [ObservableProperty]
        private bool isLoadingData;

        [ObservableProperty]
        private string? productUrl;
        [ObservableProperty]
        private string? productName;
        [ObservableProperty]
        private string? productDescription;
        [ObservableProperty]
        private double productPrice;
        [ObservableProperty]
        private bool productIsCompleted;
        [ObservableProperty]
        private string? productLink;

        private IProductRepositories _repository;
        private Product _product;
        public AddProductPageViewModel()
        {
            
        }
        public AddProductPageViewModel(MainPageViewModel mainPageViewModel)
        {
            _repository = new ProductRepositories();
            _product = new Product();
            _webScrapingService = new WebScrapingService();

        }

        [RelayCommand]
        private void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
       
        [RelayCommand]
        private async void AddInDataBase()
        {
            bool valid = ValidateData();
            if (valid)
            {
                IsLoadingData = true;
                var scrapedProductData = WebScrapingService.ScrapeProductData(ProductLink);
                var scrapedProductData2 = WebScrapingService.ScrapeProductDataStore2(ProductLink);
                if (scrapedProductData != null)
                {
                    _product.Name = scrapedProductData.Name;
                    _product.Description = scrapedProductData.Description;
                    if (scrapedProductData.Price == 0)
                    {
                        _product.Price = ProductPrice;
                    }
                    else
                    {
                        _product.Price = scrapedProductData.Price;
                    }
                    _product.imagemUrl = scrapedProductData.imagemUrl;
                }
                else
                {
                    if(scrapedProductData2 != null)
                    {
                        _product.Name = scrapedProductData2.Name;
                        _product.Description = scrapedProductData2.Description;
                        if (scrapedProductData2.Price == 0)
                        {
                            _product.Price = ProductPrice;
                        }
                        else
                        {
                            _product.Price = scrapedProductData2.Price;
                        }
                        _product.imagemUrl = scrapedProductData2.imagemUrl;
                    }
                    else
                    {
                        _product.Name = ProductName;
                        _product.Description = ProductDescription;
                        _product.Price = ProductPrice;
                        _product.imagemUrl = "não foi encontrado imagem";
                    }
                   
                }
                _product.IsCompleted = false;
                IsLoadingData = false;

                _repository.Add(_product);
                MessengerHelper.SendReloadDataMessage();
                await Shell.Current.GoToAsync("..");
            }
        }

        private bool ValidateData()
        {
            bool validResult = true;
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                validResult = false;
            }
            if (string.IsNullOrWhiteSpace(ProductDescription))
            {
                validResult = false;
            }
            if (ProductPrice <= 0)
            {
                validResult = false;
            }
            return validResult;
        }
        
    }
}
