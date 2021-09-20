using Clothing.Database;
using Clothing.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Services
{
    public class ProductsServices
    {
        public List<Product> GetProducts()
        {
            using (var context = new ClothingContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new ClothingContext())
            {
                return context.Products.Find(ID);
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = new ClothingContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new ClothingContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new ClothingContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
