using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Model;
using ProductManagement.Api.Model.Order;
using ProductManagement.Business.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("api/order/create_order")]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            var order=_orderService.CreateOrder(createOrderDto.ProductCode, createOrderDto.Quantity);

            if (order != null)
            {
                return Ok(new ResponseModel<CreateOrderDto>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = $"Order created; product {createOrderDto.ProductCode}, quantity {createOrderDto.Quantity}",
                    Response = null
                });
            }
            else
            {
                return NotFound(new ResponseModel<CreateOrderDto>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Order is not created",
                    Response = null
                });
            }

        }

    }
}
