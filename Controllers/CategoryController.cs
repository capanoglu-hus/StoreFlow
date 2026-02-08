using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreContext _context;
        public CategoryController(StoreContext context)
        {
            _context = context;
        }


        public IActionResult CategoryList()
        {
            var values = _context.Categoryies.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            category.CategoryStatus = false;
            _context.Categoryies.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categoryies.Find(id);
            _context.Categoryies.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categoryies.Find(id);
            return View(value);
            
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categoryies.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult ReverseCategory()
        {
            var categoryValues = _context.Categoryies.First();
            ViewBag.category = categoryValues.CategoryName;

            var categoryValues2 = _context.Categoryies.SingleOrDefault(x => x.CategoryName == "Elektronik");
            ViewBag.category2 = categoryValues2.CategoryStatus +"-"+ categoryValues2.CategoryId.ToString();

            var values = _context.Categoryies.OrderBy(x => x.CategoryId).Reverse().ToList();
            return View(values);
        }
    }
}
