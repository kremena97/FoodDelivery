using System.Collections.Generic;
using FoodDelivery.Data.Models;

namespace FoodDelivery.Services.Contracts
{
    public interface IOrdersService
    {
        Order CreateOrder(string username);

        Order GetProcessingOrder(string username);

        void CompleteProcessingOrder(string username, bool isPartnerOrAdmin);

        Order GetOrderById(string orderId);

        void SetOrderDetails(Order order, string fullName, string phoneNumber,  string deliveryAddressId, decimal deliveryPrice);

        void ProcessOrder(string id);

        IEnumerable<Order> GetUserOrders(string name);

        IEnumerable<Order> GetUnprocessedOrders();

        IEnumerable<Order> GetProcessedOrders();

        void DeliverOrder(string id);

        IEnumerable<OrderProduct> OrderProductsByOrderId(string id);

        Order GetUserOrderById(string orderId, string username);

        IEnumerable<Order> GetDeliveredOrders();
        
    }
}
