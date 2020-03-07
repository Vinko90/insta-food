using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models.ViewModels;
using InstaFood.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;

namespace InstaFood.WebUI.Pages.Admin.MenuItem
{
    [Authorize(Roles = StaticDetails.ManagerRole)]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public MenuItemVM MenuItemObj { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            MenuItemObj = new MenuItemVM
            {
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                FoodTypeList = _unitOfWork.FoodType.GetFoodTypeListForDropDown(),
                MenuItem = new Models.MenuItem()
            };

            if (id != null)
            {
                MenuItemObj.MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);

                if (MenuItemObj.MenuItem == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (MenuItemObj.MenuItem.Id == 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"dist\img\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                MenuItemObj.MenuItem.Image = @"\dist\img\menuItems\" + fileName + extension;

                _unitOfWork.MenuItem.Add(MenuItemObj.MenuItem);
            }
            else
            {
                //Edit menuitem
                var objFromDb = _unitOfWork.MenuItem.Get(MenuItemObj.MenuItem.Id);

                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"dist\img\menuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    MenuItemObj.MenuItem.Image = @"\dist\img\menuItems\" + fileName + extension;
                }
                else
                {
                    MenuItemObj.MenuItem.Image = objFromDb.Image;
                }


                _unitOfWork.MenuItem.Update(MenuItemObj.MenuItem);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}