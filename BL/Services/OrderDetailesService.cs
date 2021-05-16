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
   public class OrderDetailesService : BaseServices
    {
        public List<OrderDetailesViewModel> GetAllOrderDetails()
        {

            return mapper.Map<List<OrderDetailesViewModel>>(TheUnitOfWork.OrderDetail.GetAllOrderDetails());
        }
        public OrderDetailesViewModel GetOrderDetails(int id)
        {
            return mapper.Map<OrderDetailesViewModel>(TheUnitOfWork.OrderDetail.GetOrderDetailsById(id));
        }



        public bool SaveNewOrderDetails(OrderDetailesViewModel OrderDetailesViewModel)
        {
            bool result = false;
            var orderDetails = mapper.Map<OrderDetails>(OrderDetailesViewModel);
            if (TheUnitOfWork.OrderDetail.Insert(orderDetails))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrderDetails(OrderDetailesViewModel OrderDetailesViewModel)
        {
            var orderDetails = mapper.Map<OrderDetails>(OrderDetailesViewModel);
            TheUnitOfWork.OrderDetail.Update(orderDetails);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrderDetails(int id)
        {
            bool result = false;

            TheUnitOfWork.OrderDetail.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderDetailsExists(OrderDetailesViewModel OrderDetailesViewModel)
        {
            OrderDetails orderDetails = mapper.Map<OrderDetails>(OrderDetailesViewModel);
            return TheUnitOfWork.OrderDetail.CheckOrderDetailsExists(orderDetails);
        }
    }
}
