using System.Collections.Generic;
using System.Linq;
using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
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
            MenuItemList = _unitOfWork.MenuItem.GetAll(null, null, "Category,FoodType");

            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
        }
    }
}