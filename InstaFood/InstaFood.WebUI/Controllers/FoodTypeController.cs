﻿using InstaFood.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InstaFood.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.FoodType.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.FoodType.GetFirstOrDefault(o => o.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error during deleting operation!" });
            }

            _unitOfWork.FoodType.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Successful deleted " + objFromDb.Name });
        }
    }
}
