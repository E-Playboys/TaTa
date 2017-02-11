using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tata.Areas.Backend.Models.Order;
using Tata.Areas.Backend.Models.Product;
using Tata.Entities;
using Tata.Entities.Enums;
using TaTa.DataAccess;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    public class OrderController : Controller
    {
        private readonly IUowProvider _uowProvider;

        public OrderController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await GetOrdersAsync(0, 10, x => x.Include(m => m.Billing)
                                                           .Include(m => m.OrderItems)
                                                           .ThenInclude(m => m.ProductPrice)
                                                           .ThenInclude(m => m.Product));

            var models = Mapper.Instance.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orders);

            return View(models);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus([FromBody]UpdateOrderStatusModel model)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var orderRepo = uow.GetRepository<Order>();
                var order = await orderRepo.GetAsync(model.OrderId);
                if (order != null)
                {
                    order.OrderStatus = model.CurrentStatus == OrderStatus.Paid ? OrderStatus.Unpaid : OrderStatus.Paid;

                    orderRepo.Update(order);
                    await uow.SaveChangesAsync();
                }

                var returnModel = Mapper.Instance.Map<Order, OrderModel>(order);
                return Json(returnModel);
            }
        }

        private async Task<IEnumerable<Order>> GetOrdersAsync(int pageIndex, int pageSize, Func<IQueryable<Order>, IQueryable<Order>> includes = null)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var orderRepo = uow.GetRepository<Order>();

                // TODO: get all for demo, fix the client side later
                var result = await orderRepo.GetAllAsync(includes: includes);

                return result;
            }
        }
    }
}
