using AutoMapper;
using BL.Bases;
using BL.Configration;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
  public  class OrderService : BaseServices
    {
        public List<OrderDetailsViewModel> GetAllOrder()
        {

            return mapper.Map<List<OrderDetailsViewModel>>(TheUnitOfWork.Order.GetAllOrder());
        }
        public OrderDetailsViewModel GetOrder(int id)
        {
            return mapper.Map<OrderDetailsViewModel>(TheUnitOfWork.Order.GetOrderById(id));
        }



        public bool SaveNewOrder(OrderDetailsViewModel orderViewModel)
        {
            bool result = false;
            var order = mapper.Map<Order>(orderViewModel);
            if (TheUnitOfWork.Order.Insert(order))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrder(OrderDetailsViewModel orderViewModel)
        {
            var order = mapper.Map<Order>(orderViewModel);
            TheUnitOfWork.Order.Update(order);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrder(int id)
        {
            bool result = false;

            TheUnitOfWork.Order.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(OrderDetailsViewModel orderViewModel)
        {
            Order order = mapper.Map<Order>(orderViewModel);
            return TheUnitOfWork.Order.CheckOrderExists(order);
        }
    }
}
