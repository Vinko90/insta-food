using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using InstaFood.Models.ViewModels;
using InstaFood.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace InstaFood.WebUI.Pages.Customer.Cart
{
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
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

        public IActionResult OnPost(string stripeToken)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderDetailsCartVM.ListCart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value).ToList();

            OrderDetailsCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusPending;
            OrderDetailsCartVM.OrderHeader.OrderDate = DateTime.Now;
            OrderDetailsCartVM.OrderHeader.UserId = claim.Value;
            OrderDetailsCartVM.OrderHeader.Status = StaticDetails.PaymentStatusPending;
            OrderDetailsCartVM.OrderHeader.PickUpTime = Convert.ToDateTime(OrderDetailsCartVM.OrderHeader.PickUpDate.ToShortDateString() + " " + OrderDetailsCartVM.OrderHeader.PickUpTime.ToShortTimeString());

            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            _unitOfWork.OrderHeader.Add(OrderDetailsCartVM.OrderHeader);
            _unitOfWork.Save();


            foreach(var item in OrderDetailsCartVM.ListCart)
            {
                item.MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(m => m.Id == item.MenuItemId);
                
                OrderDetails orderDetails = new OrderDetails
                {
                    MenuItemId = item.MenuItemId,
                    OrderId = OrderDetailsCartVM.OrderHeader.Id,
                    Description = item.MenuItem.Description,
                    Name = item.MenuItem.Name,
                    Price = item.MenuItem.Price,
                    Count = item.Count
                };

                OrderDetailsCartVM.OrderHeader.OrderTotal += (orderDetails.Count * orderDetails.Price);

                _unitOfWork.OrderDetails.Add(orderDetails);
            }

            _unitOfWork.ShoppingCart.RemoveRange(OrderDetailsCartVM.ListCart);

            HttpContext.Session.SetInt32(StaticDetails.ShoppingCart, 0);

            _unitOfWork.Save();

            if (stripeToken != null)
            {
                // `source` is obtained with Stripe.js; see https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token
                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(OrderDetailsCartVM.OrderHeader.OrderTotal * 100), //Amount is in cents
                    Currency = "usd",
                    Source = stripeToken,
                    Description = "Order ID: " + OrderDetailsCartVM.OrderHeader.Id,
                };
                var service = new ChargeService();
                Charge charge = service.Create(options);

                OrderDetailsCartVM.OrderHeader.TransactionId = charge.Id;

                if (charge.Status.ToLower() == "succeeded")
                {
                    //Email
                    OrderDetailsCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusApproved;
                    OrderDetailsCartVM.OrderHeader.Status = StaticDetails.StatusSubmitted;
                }
                else
                {
                    OrderDetailsCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusRejected;
                }
            }
            else
            {
                OrderDetailsCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusRejected;
            }

            _unitOfWork.Save();

            return RedirectToPage("/Customer/Cart/OrderConfirmation", new { id = OrderDetailsCartVM.OrderHeader.Id});
        }
    }
}