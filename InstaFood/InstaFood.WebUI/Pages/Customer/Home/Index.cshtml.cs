using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using InstaFood.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstaFood.WebUI.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<MenuItem> MenuItemList { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                int shoppingCartCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(StaticDetails.ShoppingCart, shoppingCartCount);
            }

            MenuItemList = _unitOfWork.MenuItem.GetAll(null, null, "Category,FoodType");

            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
        }
    }
}