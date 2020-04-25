using ElevenNote.Data;
using ElevenNote.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();
        public void CreateCategory(CategoryCreate model)
        {
            var categoryToCreate = new Category()
            {
                CategoryName = model.CategoryName
            };
            _ctx.Categories.Add(categoryToCreate);
            _ctx.SaveChanges();
        }
        public List<CategoryListItem> GetCategories()
        {
            return _ctx.Categories.Select(category => new CategoryListItem()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            }).ToList();
        }
        public CategoryDetail GetCategoryById(int id)
        {
            var categoryToGet = _ctx.Categories.Single(category => category.CategoryId == id);
            return new CategoryDetail()
            {
                CategoryId = categoryToGet.CategoryId,
                CategoryName = categoryToGet.CategoryName
            };
        }
        public void UpdateCategory(CategoryEdit model)
        {
            var categoryToUpdate = _ctx.Categories.Find(model.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = model.CategoryName;
                _ctx.SaveChanges();
            }
        }
        public void DeleteCategory(CategoryDelete model)
        {
            Category categoryToDelete = _ctx.Categories.Find(model.CategoryId);
            _ctx.Categories.Remove(categoryToDelete);
            _ctx.SaveChanges();
        }
    }
}
