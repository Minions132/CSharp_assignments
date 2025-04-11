namespace OrderManagementApi.Models{
    public class Order{
        public int Id { get; set; }
        public string Customer { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public Order(int id, string customer, double amount, DateTime orderDate){
            Id = id;
            Customer = customer;
            Amount = amount;
            OrderDate = orderDate;
        }    
        public override string ToString(){
            return $"Order ID: {Id}, Customer: {Customer}, Amount: {Amount}, Order Date: {OrderDate}";
        }
    }
}