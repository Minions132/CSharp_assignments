using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement_Win{
    public class OrderService{
        private List<Order> orders;
        public OrderService(){
            orders = new List<Order>();
        }
        public void AddOrder(Order order){
            if(orders.Any(o => o.Id == order.Id)){
                throw new Exception("订单ID已存在!");
            }
            orders.Add(order);
        }
        public void DeleteOrder(int id){
            var order = orders.FirstOrDefault(o => o.Id == id);
            if(order == null){
                throw new Exception("订单不存在!");
            }
            orders.Remove(order);
        }
        public void UpdateOrder(Order updateorder){
            var order = orders.FirstOrDefault(o => o.Id == updateorder.Id);
            if(order == null){
                throw new Exception("订单不存在!");
            }
            order.Customer = updateorder.Customer;
            order.Amount = updateorder.Amount;
            order.OrderDate = updateorder.OrderDate;
        }
        public Order GetOrderById(int id){
            return orders.FirstOrDefault(o => o.Id == id);
        }
        public List<Order> GetAllOrders(){
            return orders;
        }
    }
}