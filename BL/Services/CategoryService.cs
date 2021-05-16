using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
   public class CategoryService: BaseServices
    {
        public List<CategoryViewModel> GetAllCategory()
        {

            return mapper.Map<List<CategoryViewModel>>(TheUnitOfWork.Category.GetAllCategory());
        }
        public CategoryViewModel GetCategory(int id)
        {
            return mapper.Map<CategoryViewModel>(TheUnitOfWork.Category.GetCategoryById(id));
        }



        public bool SaveNewCategory(CategoryViewModel categoryViewModel)
        {
            bool result = false;
            var category = mapper.Map<Category>(categoryViewModel);
            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var category = mapper.Map<Category>(categoryViewModel);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public bool CheckCategoryExists(CategoryViewModel categoryViewModel)
        {
            Category category = mapper.Map<Category>(categoryViewModel);
            return TheUnitOfWork.Category.CheckCategoryExists(category);
        }
    }
}
