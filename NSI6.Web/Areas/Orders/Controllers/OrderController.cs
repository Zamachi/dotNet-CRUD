using Microsoft.AspNetCore.Mvc;
using NSI6.Service;
using NSI6.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Web.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Route("Orders/[controller]/[action]/{id?}")]
    public class OrderController : BaseController
    {
        private IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        [HttpGet]
        public IActionResult getAllOrders()
        {

            return View(OrderService.getAllOrders());
        }

        [HttpGet]
        public IActionResult getOneOrder(int id)
        {
            return View(OrderService.getOrderById(id, CultureInfo.CurrentCulture.Name));
        }

    }
}
