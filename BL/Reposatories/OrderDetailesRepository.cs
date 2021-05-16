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
    public class OrderDetailesRepository : BaseRepository<OrderDetails>
    {

        private DbContext EC_DbContext;

        public OrderDetailesRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }


        public List<OrderDetails> GetAllOrderDetails()
        {
            return GetAll().ToList();
        }

        public bool InsertOrderDetails(OrderDetails orderdetail)
        {
            return Insert(orderdetail);
        }
        public void UpdateOrderDetails(OrderDetails orderdetails)
        {
            Update(orderdetails);
        }
        public void DeleteOrderDetails(int id)
        {
            Delete(id);
        }

        public bool CheckOrderDetailsExists(OrderDetails orderdetails)
        {
            return GetAny(orderd => orderd.Id == orderdetails.Id);
        }
        public OrderDetails GetOrderDetailsById(int id)
        {
            return GetFirstOrDefault(orderd => orderd.Id == id);
        }

    }
}
