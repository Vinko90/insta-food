using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using InstaFood.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace InstaFood.WebUI.Pages.Customer.Cart
{
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailsCartVM OrderDetailsCartVM { get; set; }

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            OrderDetailsCartVM = new OrderDetailsCartVM()
            {
                OrderHeader = new OrderHeader()
            };

            OrderDetailsCartVM.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            IEnumerable<ShoppingCart> cart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value);

            if (cart != null)
            {
                OrderDetailsCartVM.ListCart = cart.ToList();
            }

            foreach (var cartList in OrderDetailsCartVM.ListCart)
            {
                cartList.MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(m => m.Id == cartList.MenuItemId);
                OrderDetailsCartVM.OrderHeader.OrderTotal += (cartList.MenuItem.Price * cartList.Count);
            }

            ApplicationUser appUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
            OrderDetailsCartVM.OrderHeader.PickUpName = appUser.FullName;
            OrderDetailsCartVM.OrderHeader.PickUpTime = DateTime.Now;
            OrderDetailsCartVM.OrderHeader.PhoneNumber = appUser.PhoneNumber;

            return Page();
        }
    }
}