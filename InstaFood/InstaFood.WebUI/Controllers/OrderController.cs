using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using InstaFood.Models.ViewModels;
using InstaFood.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;

namespace InstaFood.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get(string status = null)
        {
            List<OrderDetailsVM> orderListVM = new List<OrderDetailsVM>();

            IEnumerable<OrderHeader> OrderHeaderList;

            if (User.IsInRole(StaticDetails.CustomerRole))
            {
                //Retrive all orders for that customer
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                OrderHeaderList = _unitOfWork.OrderHeader.GetAll(u => u.UserId == claim.Value, null, "ApplicationUser");
            }
            else
            {
                OrderHeaderList = _unitOfWork.OrderHeader.GetAll(null, null, "ApplicationUser");
            }

            switch (status)
            {
                case StaticDetails.StatusCancelled: OrderHeaderList = OrderHeaderList.Where(o => o.Status == StaticDetails.StatusCancelled || o.Status == StaticDetails.StatusRefunded || o.Status == StaticDetails.PaymentStatusRejected); break;
                case StaticDetails.StatusCompleted: OrderHeaderList = OrderHeaderList.Where(o => o.Status == StaticDetails.StatusCompleted); break;
                default: OrderHeaderList = OrderHeaderList.Where(o => o.Status == StaticDetails.StatusReady || o.Status == StaticDetails.StatusInProcess || o.Status == StaticDetails.StatusSubmitted || o.Status == StaticDetails.PaymentStatusPending); break;
            };

            foreach (OrderHeader item in OrderHeaderList)
            {
                OrderDetailsVM orderDetailItem = new OrderDetailsVM
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderId == item.Id).ToList()
                };

                orderListVM.Add(orderDetailItem);
            }

            return Json(new { data = orderListVM });
        }
    }
}