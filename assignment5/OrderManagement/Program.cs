using System;
using System.Linq;
using System.Collections.Generic;

namespace OrderManagement{
    public class Order{
        public int Id{get; set;}
        public string Customer{get; set;}
        public Order(int id, string customer) => (Id, Customer) = (id, customer);
        public override string ToString() => $"Order Id : {Id}, Customer : {Customer}";
        public override bool Equals(object? obj) => obj is Order other && Id == other.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
    public class OrderDetails : Order{
        public string Product{get; set;}
        public double Price{get; set;}
        public OrderDetails(int id, string customer, string product, double price) : base(id, customer){
            Product = product;
            Price = price;
        }
        public override string ToString() => $"{base.ToString()}, Product : {Product}, Price : {Price}";
        public override bool Equals(object? obj) => obj is OrderDetails other && Id == other.Id && Product == other.Product;
        public override int GetHashCode() => HashCode.Combine(Id, Product);
    }
    public class OrderService : Order{
        private List<Order> orders = new List<Order>();
        public OrderService(int id, string customer) : base(id, customer) {}
        public void AddOrder(Order order){
            if(orders.Any(o => o.Equals(order)))
                throw new Exception("Order exists");
            orders.Add(order);
        }
        public void RemoveOrder(int orderId){
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            if(order == null) throw new Exception("Order doesn't exist");
            orders.Remove(order);
        }
        public void UpdateOrder(int OrderId, string newCustomer){
            var order = orders.FirstOrDefault(o => o.Id == OrderId);
            if(order == null) throw new Exception("Order doesn't exist");
            order.Customer = newCustomer;
        }
        public List<Order> QueryOrders(Func<Order, bool> predicate) => orders.Where(predicate).ToList();
        public void SortOrders() => orders.Sort((x, y) => x.Id.CompareTo(y.Id));
    }
    class Program{
        static void Main(string[] args){
            var service = new OrderService(0, "System");
            var order1 = new Order(1, "Jason");
            var detail1 = new OrderDetails(1, "Jason", "Book", 20);
            var detail2 = new OrderDetails(1, "Jason", "Tablet", 800);
            
            var order2 = new Order(2, "Bob");
            var detail3 = new OrderDetails(2, "Bob", "Laptop", 2000);
            //Add Orders
            service.AddOrder(order1);
            service.AddOrder(order2);
            //Query Orders
            var result = service.QueryOrders(o => o.Customer == "Jason");
            Console.WriteLine("Order for Jason:");
            result.ForEach(o => Console.WriteLine(o));
            //Modify Orders
            service.UpdateOrder(1, "Jason Updated");
            Console.WriteLine("\nAfter updated:");
            service.QueryOrders(o => o.Id == 1).ForEach(o => Console.WriteLine(o));
            //Sort and display all orders
            service.SortOrders();
            Console.WriteLine("\nAll orders sorted by Id:");
            service.QueryOrders(_ => true).ForEach(o => Console.WriteLine(o));
            //Display the order details
            Console.WriteLine("\nOrder Details:");
            Console.WriteLine(detail1);
            Console.WriteLine(detail2);
            Console.WriteLine(detail3);
        }
    }
}