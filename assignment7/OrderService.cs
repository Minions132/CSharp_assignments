using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement_Win{
    public class OrderService{
        private readonly OrderDbContext _context;
        public OrderService(){
            _context = new OrderDbContext();
            _context.Database.EnsureCreated();
        }
        public void AddOrder(Order order){
            if(_context.Orders.Any(o => o.Id == order.Id)){
                throw new Exception("订单ID已存在!");
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void DeleteOrder(int id){
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if(order == null){
                throw new Exception("订单不存在!");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
        public void UpdateOrder(Order updateorder){
            var order = _context.Orders.FirstOrDefault(o => o.Id == updateorder.Id);
            if(order == null){
                throw new Exception("订单不存在!");
            }
            order.Customer = updateorder.Customer;
            order.Amount = updateorder.Amount;
            order.OrderDate = updateorder.OrderDate;
            _context.SaveChanges();
        }
        public Order GetOrderById(int id){
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
        public List<Order> GetAllOrders(){
            return _context.Orders.ToList();
        }
    }
}