using BL.Services;
using DAL;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.MyHubs
{
    [HubName("ProductHub")]
    public class ProductHub:Hub
    {
        ProductService productService = new ProductService();

        [HubMethodName("WriteComment")]
        public void WriteComment(string username, string comment, int PID)
        {
            Clients.All.Comment(username, comment, PID);

        }
        [HubMethodName("BuyProduct")]
        public void BuyProduct(int PID)
        {
   

            var pro = productService.GetProduct(PID);
            pro.Quantity--;
            productService.SaveNewProduct(pro);
            Clients.All.ReduceProductQuantity(PID, pro.Quantity);

        }
    }
}