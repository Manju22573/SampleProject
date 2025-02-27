using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Orders;
using Sparrow;
using WebApi.Models.Order;
using WebApi.Models.Users;


namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var order = _getOrderService.GetOrder(orderId);
            if (order != null)
            {
                return Found("Order Already exists");
            }
            order = _createOrderService.Create(orderId, model.IsProcessed, model.OrderDate, model.Quantity, model.ProductId , model.UserId, model.TotalPrice);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null){
                return DoesNotExist();
            }
            _updateOrderService.Update(order, model.IsProcessed, model.OrderDate, model.Quantity, model.ProductId, model.UserId,model.TotalPrice);
            var result = new  { orderId = order.Id,quantity = order.Quantity,totalPrice = order.TotalPrice,orderDate = order.OrderDate, isProcessed = order.IsProcessed };
            return Found(result);
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(order);
            return Found("Order deleted Succesfully");
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            var result = new
            {
                OrderId = order.Id,
                quantity = order.Quantity,
                totalPrice = order.TotalPrice,
                orderDate = order.OrderDate,
                isProcessed = order.IsProcessed,
            };

            return Found(result);
           
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, string productId = null, int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null , string userId = null)
        {
            var orders = _getOrderService.GetOrders(productId, userId, quantity, orderDate, isProcessed)
                                         .Skip(skip).Take(take)
                                         .Select(q => new OrderData(q))                                        
                                         .ToList();
            return Found(orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }


    }
}
