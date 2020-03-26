using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using InstaFood.Models.ViewModels;
using InstaFood.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;

namespace InstaFood.WebUI.Pages.Admin.Order
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public OrderDetailsVM OrderDetailsVM { get; set; }

        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            OrderDetailsVM = new OrderDetailsVM()
            {
                OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(m => m.Id == id),
                OrderDetails = _unitOfWork.OrderDetails.GetAll(m => m.OrderId == id).ToList()
            };

            OrderDetailsVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == OrderDetailsVM.OrderHeader.UserId);
        }
        public IActionResult OnPostOrderConfirm(int orderId)
        {
            OrderHeader orderheader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);
            orderheader.Status = StaticDetails.StatusCompleted;
            _unitOfWork.Save();
            return RedirectToPage("OrderList");
        }

        public IActionResult OnPostOrderCancel(int orderId)
        {
            OrderHeader orderheader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);
            orderheader.Status = StaticDetails.StatusCancelled;
            _unitOfWork.Save();
            return RedirectToPage("OrderList");
        }

        public IActionResult OnPostOrderRefund(int orderId)
        {
            OrderHeader orderheader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);

            //Refund amount on Stripe
            var options = new RefundCreateOptions
            {
                Amount = Convert.ToInt32(orderheader.OrderTotal * 100),
                Reason = RefundReasons.RequestedByCustomer,
                Charge = orderheader.TransactionId
            };
            var service = new RefundService();
            service.Create(options);

            orderheader.Status = StaticDetails.StatusRefunded;
            _unitOfWork.Save();
            return RedirectToPage("OrderList");
        }
    }
}