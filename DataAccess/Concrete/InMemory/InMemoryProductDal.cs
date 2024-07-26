using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryiId=1, ProductName="Bardak", UnitPrice=20, UnitsInStock=20},
                new Product{ProductId=2, CategoryiId=1, ProductName="Tabak", UnitPrice=35, UnitsInStock=10},
                new Product{ProductId=3, CategoryiId=2, ProductName="Masa", UnitPrice=500, UnitsInStock=40},
                new Product{ProductId=4, CategoryiId=2, ProductName="Sandalye", UnitPrice=100, UnitsInStock=80},
                new Product{ProductId=5, CategoryiId=2, ProductName="Minder", UnitPrice=50, UnitsInStock=80}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryiId = product.CategoryiId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryiId == categoryId).ToList ();

        }
    }
}
