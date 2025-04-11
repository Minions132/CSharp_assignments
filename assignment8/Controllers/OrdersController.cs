using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.Models;
using OrderManagementApi.Services;

namespace OrderManagementApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase{
        private readonly OrderService _orderService;
        public OrdersController(OrderService orderService){
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders(){
            try{
                var orders = _orderService.GetAllOrders();
                return Ok(orders);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id){
            try{
                var order = _orderService.GetOrderById(id);
                if(order == null){
                    return NotFound($"Order with ID {id} not found.");  
                }
                return Ok(order);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddOrder([FromBody] Order order){
            try{
                _orderService.AddOrder(order);
                return Ok("Order added successfully.");
            }
            catch (Exception ex){
                return BadRequest($"Error adding order: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, [FromBody] Order order){
            try{
                if(id != order.Id){
                    return BadRequest("Order ID mismatch.");
                }
                _orderService.UpdateOrder(order);
                return Ok("Order updated successfully.");
            }
            catch (Exception ex){
                return BadRequest($"Error updating order: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id){
            try{
                _orderService.DeleteOrder(id);
                return Ok("Order deleted successfully.");
            }
            catch (Exception ex){
                return BadRequest($"Error deleting order: {ex.Message}");
            }
        }
    }
}