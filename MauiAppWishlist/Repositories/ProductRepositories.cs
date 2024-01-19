using AppWishList.Database;
using AppWishList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        private AppWishContext _db;
        public ProductRepositories()
        {
            _db = new AppWishContext();
        }
        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Delete(Product product)
        {
            product = GetById(product.Id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public void Update(List<Product> product)
        {
            _db.Products.UpdateRange(product);
            _db.SaveChanges();
        }
    }
}
