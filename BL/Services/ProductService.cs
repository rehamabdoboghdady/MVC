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
   public class ProductService : BaseServices
    {
        public List<ProductViewModel> GetAllProduct()
        {

            return mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetAllProduct());
        }
        public ProductViewModel GetProduct(int id)
        {
            return mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetProductById(id));
        }



        public bool SaveNewProduct(ProductViewModel productViewModel)
        {
            bool result = false;
            var product = mapper.Map<Product>(productViewModel);
            if (TheUnitOfWork.Product.Insert(product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateProduct(ProductViewModel ProductViewModel)
        {
            var Product = mapper.Map<Product>(ProductViewModel);
            TheUnitOfWork.Product.Update(Product);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteProduct(int id)
        {
            bool result = false;

            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckProductExists(ProductViewModel ProductViewModel)
        {
            Product Product = mapper.Map<Product>(ProductViewModel);
            return TheUnitOfWork.Product.CheckProductExists(Product);
        }


        public List<ProductViewModel> Search(string ProductName)
        {
            IQueryable<Product> products = TheUnitOfWork.Product.GetAll().Where(p => p.Name.Contains(ProductName));

            return mapper.Map<List<ProductViewModel>>(products);
        }

    }
}
