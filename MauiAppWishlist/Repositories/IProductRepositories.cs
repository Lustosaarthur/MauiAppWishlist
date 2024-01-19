﻿using AppWishList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.Repositories
{
    public interface IProductRepositories
    {
        IList<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Update(List<Product> product);
        void Delete(Product product);
    }
}
