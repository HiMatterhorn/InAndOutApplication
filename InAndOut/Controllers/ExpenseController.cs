using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }

        //GET - Create
        public IActionResult Create()
        {

            //Moved to ViewModel
            /*            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }) ;

                         ViewBag.TypeDropDown = TypeDropDown;
            */

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }
  
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST - Create
        public IActionResult Create(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();

                return (RedirectToAction("Index"));
            }

            return View(obj);
        }


        //GET - Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST - Delete
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return (RedirectToAction("Index"));

        }

        //GET - Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST - Update
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();

                return (RedirectToAction("Index"));
            }

            return View(obj);
        }
    }
}
