using System;
using System.Collections.Generic;
using System.Linq;
using OrderManagementApi.Models;

namespace OrderManagementApi.Services{
    public class OrderService{
        private List<Order> orders;
        public OrderService(){
            orders = new List<Order>();
        }
        public void AddOrder(Order order){
            if(orders.Any(o => o.Id == order.Id)){
                throw new Exception("Order with this ID already exists.");
            }
            orders.Add(order);
        }
        public void DeleteOrder(int id){
            var order = orders.FirstOrDefault(o => o.Id == id);
            if(order == null){
                throw new Exception("Order not found.");
            }
            orders.Remove(order);
        }
        public void UpdateOrder(Order updatedOrder){
            var order = orders.FirstOrDefault(o => o.Id == updatedOrder.Id);
            if(order == null){
                throw new Exception("Order not found.");
            }
            order.Customer = updatedOrder.Customer;
            order.Amount = updatedOrder.Amount;
            order.OrderDate = updatedOrder.OrderDate;
        }
        public Order GetOrderById(int id){
            var order = orders.FirstOrDefault(o => o.Id == id);
            if(order == null){
                throw new Exception("Order not found.");
            }
            return order;
        }
        public List<Order> GetAllOrders(){
            return orders;
        }
    }
}