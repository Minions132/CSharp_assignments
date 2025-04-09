using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement_Win{
    public class Order{
        public int Id { get; set; }
        public string Customer { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public Order(){}
        public Order(int id, string customer, double amount, DateTime orderdate){
            Id = id;
            Customer = customer;
            Amount = amount;
            OrderDate = orderdate;
        }
        public override string ToString(){
            return $"订单ID:{Id}, 客户:{Customer}, 金额:{Amount}, 日期:{OrderDate.ToShortDateString()}";
        }
    }
}