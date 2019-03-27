using FoodDelivery.Data.Models;
using FoodDelivery.Data.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodDelivery.Data;
using FoodDelivery.Services.Contracts;

namespace SaltNPepa.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        private readonly FoodDeliveryContext _db;

        public OrdersService(IUserService userService, ICartService shoppingCartService, FoodDeliveryContext db)
        {
            this._userService = userService;
            this._cartService = shoppingCartService;
            this._db = db;
        }

        public Order CreateOrder(string username)
        {
            var user = _userService.GetUserByUsername(username);

            var order = new Order()
            {
                FoodDeliveryUser = user,
                OrderStatus = OrderStatus.Processing
            };

            this._db.Orders.Add(order);
            this._db.SaveChanges();

            return order;
        }

        public Order GetProcessingOrder(string username)
        {
            var user = this._userService.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            var order = this._db.Orders.Include(x => x.DeliveryAddress)
                .ThenInclude(x => x.City)
                .Include(x => x.OrderProducts)
                .FirstOrDefault(x => x.FoodDeliveryUser.UserName == username && x.OrderStatus == OrderStatus.Processing);

            return order;
        }

        public void CompleteProcessingOrder(string username, bool isPartnerOrAdmin)
        {
            var order = this.GetProcessingOrder(username);
            if (order == null)
            {
                return;
            }

            var cartProducts = this._cartService.GetAllCartProducts(username).ToList();
            if (cartProducts.Count == 0)
            {
                return;
            }

            List<OrderProduct> orderProducts = new List<OrderProduct>();

            foreach (var cartProduct in cartProducts)
            {
                var orderProduct = new OrderProduct
                {
                    Order = order,
                    Product = cartProduct.Product,
                    Quantity = cartProduct.Quantity,
                    Price =  cartProduct.Product.Price
                };

                orderProducts.Add(orderProduct);
            }

            this._cartService.DeleteAllProductFromCart(username);

            order.OrderTime = DateTime.UtcNow;
            order.OrderProducts = orderProducts;
            order.TotalPrice = order.OrderProducts.Sum(x => x.Quantity * x.Price);

            this._db.SaveChanges();
        }

        public Order GetOrderById(string orderId)
        {
            return this._db.Orders
                .FirstOrDefault(x => x.Id == orderId);
        }

        public void SetOrderDetails(Order order, string fullName, string phoneNumber, string deliveryAddressId, decimal deliveryPrice)
        {
            throw new System.NotImplementedException();
        }

        public void ProcessOrder(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetUserOrders(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetUnprocessedOrders()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            throw new System.NotImplementedException();
        }

        public void DeliverOrder(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderProduct> OrderProductsByOrderId(string id)
        {
            throw new System.NotImplementedException();
        }

        public Order GetUserOrderById(string orderId, string username)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetDeliveredOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}
