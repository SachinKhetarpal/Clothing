using Clothing.Database;
using Clothing.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Services
{
    public class CategoriesServices
    {
        public List<Category> GetCategories()
        {
            using (var context = new ClothingContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategory(int ID)
        {
            using (var context = new ClothingContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new ClothingContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new ClothingContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
