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
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using Tata.Helpers;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        private readonly IUowProvider _uowProvider;
        private readonly IEmailHelper _emailHelper;

        public OrderController(IUowProvider uowProvider, IEmailHelper emailHelper)
        {
            _uowProvider = uowProvider;
            _emailHelper = emailHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await GetOrdersAsync(0, 10, x => x.Include(m => m.CreatedUser).Include(m => m.OrderItems)
                                                           .ThenInclude(m => m.Product));

            var models = Mapper.Instance.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orders);

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new OrderDetailsViewModel();
            if (id > 0)
            {
                var order = await GetOrderAsync(id, x => x.Include(m => m.CreatedUser)
                                                    .Include(m => m.OrderItems).ThenInclude(m => m.Product)
                                                    .Include(m => m.OrderItems).ThenInclude(m => m.ExtraProperties));

                model.Order = Mapper.Instance.Map<Order, OrderModel>(order);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus([FromBody]UpdateOrderStatusModel model)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var orderRepo = uow.GetRepository<Order>();
                var userProductRepo = uow.GetRepository<UserProduct>();

                var order = await orderRepo.GetAsync(model.OrderId, x => x.Include(m => m.CreatedUser)
                                                    .Include(m => m.OrderItems).ThenInclude(m => m.Product)
                                                    .Include(m => m.OrderItems).ThenInclude(m => m.ExtraProperties));
                if (order != null)
                {
                    order.OrderStatus = model.CurrentStatus == OrderStatus.Paid ? OrderStatus.Unpaid : OrderStatus.Paid;
                    orderRepo.Update(order);

                    // TODO: user product here
                    //var userProduct = new UserProduct
                    //{

                    //};

                    //userProductRepo.Add(userProduct);

                    await uow.SaveChangesAsync();
                }

                var returnModel = Mapper.Instance.Map<Order, OrderModel>(order);
                return PartialView("_Order", returnModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderItemStatus([FromBody]UpdateOrderItemStatusModel model)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var orderItemRepo = uow.GetRepository<OrderItem>();

                var orderItem = await orderItemRepo.GetAsync(model.OrderItemId, x => x.Include(m => m.Order).ThenInclude(m =>m .CreatedUser).Include(m => m.Product)
                                                                                .Include(m => m.ExtraProperties));
                if (orderItem != null)
                {
                    switch (model.CurrentStatus)
                    {
                        case OrderItemStatus.NotProcess:
                            orderItem.Status = OrderItemStatus.Processing;
                            break;
                        case OrderItemStatus.Processing:
                            orderItem.Status = OrderItemStatus.Done;
                            break;
                    }

                    orderItemRepo.Update(orderItem);

                    //await uow.SaveChangesAsync();

                    if (orderItem.Status == OrderItemStatus.Done)
                    {
                        // email vps info
                        var recipientName = orderItem.Order.CreatedUser.FullName;
                        var recipientAddress = orderItem.Order.CreatedUser.Email;

                        var bodyBuilder = new BodyBuilder
                        {
                            HtmlBody = 
$@"<p><strong>VPS Information</strong></p>
<ul>
<li>IP: {model.VpsIpAddress}</li>
<li>Username: {model.VpsUsername}</li>
<li>Password: {model.VpsPassword}</li>
</ul>"
                        };
                        var body = bodyBuilder.ToMessageBody();

                        await _emailHelper.SendEmailAsync(recipientName, recipientAddress, "VPS Information", body);
                    }
                }

                var returnModel = Mapper.Instance.Map<OrderItem, OrderItemModel>(orderItem);
                return PartialView("_OrderItem", returnModel);
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

        private async Task<Order> GetOrderAsync(int id, Func<IQueryable<Order>, IQueryable<Order>> includes = null)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var orderRepo = uow.GetRepository<Order>();

                var result = await orderRepo.GetAsync(id, includes);

                return result;
            }
        }
    }
}
