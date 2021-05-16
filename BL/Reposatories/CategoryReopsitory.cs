using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reposatories
{
    public class CategoryReopsitory : BaseRepository<Category>
    {
        private DbContext EC_DbContext;

        public CategoryReopsitory(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }


        public List<Category> GetAllCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertCategory(Category category)
        {
            return Insert(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }
        public void DeleteCategory(int id)
        {
            Delete(id);
        }

        public bool CheckCategoryExists(Category category)
        {
            return GetAny(cat => cat.Id == category.Id);
        }
        public Category GetCategoryById(int id)
        {
            return GetFirstOrDefault(cat => cat.Id == id);
        }
    }
}
