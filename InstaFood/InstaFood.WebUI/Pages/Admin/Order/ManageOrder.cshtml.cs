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
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public List<OrderDetailsVM> orderDetailsVM { get; set; }

        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            orderDetailsVM = new List<OrderDetailsVM>();

            List<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader
                .GetAll(o => o.Status == StaticDetails.StatusSubmitted || o.Status == StaticDetails.StatusInProcess)
                .OrderByDescending(u => u.PickUpTime)
                .ToList();

            foreach (OrderHeader item in orderHeaderList)
            {
                OrderDetailsVM orderDetailItem = new OrderDetailsVM
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderId == item.Id).ToList()
                };

                orderDetailsVM.Add(orderDetailItem);
            }
        }

        public IActionResult OnPostOrderPrepare(int orderId)
        {
            OrderHeader orderheader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);
            orderheader.Status = StaticDetails.StatusInProcess;
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }

        public IActionResult OnPostOrderReady(int orderId)
        {
            OrderHeader orderheader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);
            orderheader.Status = StaticDetails.StatusReady;
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }

        public IActionResult OnPostOrderCancel(int orderId)
        {
            OrderHeader orderheader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);
            orderheader.Status = StaticDetails.StatusCancelled;
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
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
            return RedirectToPage("ManageOrder");
        }
    }
}