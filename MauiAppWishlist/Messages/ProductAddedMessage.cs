
using AppWishList.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Collections.ObjectModel;

namespace MauiAppWishlist.Messages;

public class ProductAddedMessage
{
    public Product Product { get; }
    public ProductAddedMessage(Product product)
    {
        Product = product;
    }
}
