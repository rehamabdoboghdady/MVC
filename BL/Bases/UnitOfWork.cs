using BL.Interfaces;
using BL.Reposatories;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext EC_DbContext { get; set; }
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();

            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }

        public ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(EC_DbContext);
                return product;
            }
        }


        public CategoryReopsitory category;
        public CategoryReopsitory Category
        {
            get
            {
                if (category == null)
                    category = new CategoryReopsitory(EC_DbContext);
                return category;
            }
        }

        public OrderDetailesRepository orderdetails;
        public OrderDetailesRepository OrderDetail
        {
            get
            {
                if (orderdetails == null)
                    orderdetails = new OrderDetailesRepository(EC_DbContext);
                return orderdetails;
            }
        }


        public OrderRepository order;
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(EC_DbContext);
                return order;
            }
        }

        public AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext);
                return account;
            }
        }

        public RoleRepository role;
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext);
                return role;
            }
        }
    }
}
