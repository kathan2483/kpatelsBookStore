using KpatelsBooks.DataAccess.Repository.IRepository;
using KpatelsBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpatelsBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)       //action method for Upsert
        {
            Category category = new Category();    //using DevanshPatelBooks.Models;
            if (id == null)
            {
                // this is for create
                return View(category);
            }
            //this for the edit
            category = _UnitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // use HTTP post to define the post-action method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)    //checks all validations in the model(e.g Name required) to increase security
            {
                if (category.Id == 0)
                {
                    _UnitOfWork.Category.Add(category);
                    _UnitOfWork.Save();
                }
                else
                {
                    _UnitOfWork.Category.Update(category);
                }
                _UnitOfWork.Save();
                return RedirectToAction(nameof(Index));         //to see all the categories
            }
            return View(category);
        }

        // API calls here
        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            //return NotFound();
            var allObj = _UnitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _UnitOfWork.Category.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _UnitOfWork.Category.Remove(objFromDb);
            _UnitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}