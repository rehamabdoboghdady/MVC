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
    public class ProductRepository : BaseRepository<Product>
    {
        private DbContext EC_DbContext;

        public ProductRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }

        public List<Product> GetAllProduct()
        {
            return GetAll().ToList();
        }

        public bool InsertProduct(Product product)
        {
            return Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }

        public bool CheckProductExists(Product product)
        {
            return GetAny(pro => pro.Id == product.Id);
        }
        public Product GetProductById(int id)
        {
            return GetFirstOrDefault(pro => pro.Id == id);
        }

       
        }
}
