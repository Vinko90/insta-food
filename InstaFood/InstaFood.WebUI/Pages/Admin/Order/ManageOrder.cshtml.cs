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
    }
}