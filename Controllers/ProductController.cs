using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult ProductList()
        {
            var values = _context.Products.Include(x => x.Category).ToList(); /* direkt category bilgilerini de getiriyor - join*/
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categories = _context.Categoryies
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList();

            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _context.Products.Find(id);
            var categories = _context.Categoryies
               .Select(c => new SelectListItem
               {
                   Value = c.CategoryId.ToString(),
                   Text = c.CategoryName
               }).ToList();

            ViewBag.categories = categories;
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult First5ProductList()
        {
            var first = _context.Products.Include(x => x.Category).Take(5).ToList();
            return View(first);
        }

        public IActionResult Skip4ProductList()
        {
            var skip = _context.Products.Include(x => x.Category).Skip(4).Take(10).ToList();
            return View(skip);
        }

        [HttpGet]
        public IActionResult CreateProductWithAttack()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateProductWithAttack(Product product)
        {
            var category = new Category { CategoryId = 1 };
            _context.Categoryies.Attach(category);

            var productValue = new Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock,
                Category = category /*ne ürün eklersen ekle categorysi elektronik , arka planda direkt atama*/
            };

            _context.Products.Add(productValue);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult ProductLongCount()
        {
            var value = _context.Products.LongCount();
            var LastProduct = _context.Products.OrderBy(x=> x.ProductId).Last();
            ViewBag.values2 = LastProduct.ProductName;
            ViewBag.values = value;
            return View();
        }

        public IActionResult ProductListWithCategories()
        {
            var result = from c in _context.Categoryies
                         join p in _context.Products
                         on
                         c.CategoryId equals p.CategoryId
                         select new ProductWithCategoryViewModel
                         {
                             ProductName= p.ProductName,
                             ProductStock= p.ProductStock,
                             CategoryName= c.CategoryName
                         };

            return View(result.ToList());

        }
    }
}
