using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;
        public CustomerController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x => x.CustomerName).ToList();
            return View(values);
        }

        public IActionResult CustomerListOrderByDescBalance()
        {
            var balance = _context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(balance);
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomergetCity(string city)
        {
            var exist = _context.Customers.Any(a => a.CustomerCity == city);
            if (exist) 
            {
                ViewBag.message = $"{city} şehrinde en az bir tane müşteri var";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok";
            }
            return View();
        }
        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers
                .ToList()
                .GroupBy(c => c.CustomerCity)
                .ToList();
            return View(groupedCustomers);
        }

        public IActionResult CustomersByCityCount()
        {
            var query =
                from c in _context.Customers
                group c by c.CustomerCity into cityGroup
                select new CustomerCityGroup
                {
                    City = cityGroup.Key,
                    CustomerCount = cityGroup.Count()
                };
            /*
             * sql groupby sorgusuyla aynı 
             * hangi şehirden kaç kişi var onu aldık 
             */
            var model = query.OrderByDescending(x => x.CustomerCount).ToList();
            return View(model);
        }

        public IActionResult CustomerCityList()
        {
            var values = _context.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }
        public IActionResult ParallelCustomers()
        {
            var customers = _context.Customers.ToList();
            var result = customers
                .AsParallel()
                .Where(c => c.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                .ToList();
            /*
             * StringComparison.OrdinalIgnoreCase -> büyük küçük uyumsuzluğundan bağımsız
            */
            return View(result);
        }

        public IActionResult CustomerListExceptCityIstanbul()
        {
            var allCustomer = _context.Customers.ToList();
            var customersListInIstanbul = _context.Customers
                .Where(x => x.CustomerCity == "İstanbul")
                .ToList();
            var result = allCustomer.Except(customersListInIstanbul).ToList();
            return View(result);
        }

        public IActionResult CustomerListWithDefaultIfEmpty()
        {
            var customers = _context.Customers.ToList().Where(x => x.CustomerCity == "Kaars")
                .DefaultIfEmpty(new Customer
                {
                    CustomerId = 0,
                    CustomerName = "Kayıt yok",
                    CustomerSurname = "----",
                    CustomerCity = "Kaars"
                }).ToList();

            return View(customers);

        }

        public IActionResult CustomerIntersectByCity()
        {
            var cityValues = _context.Customers.Where(x => x.CustomerCity == "İstanbul")
                .Select(y => y.CustomerName + y.CustomerSurname)
                .ToList();


            var cityValues2 = _context.Customers.Where(x => x.CustomerCity == "Ankara")
                .Select(y => y.CustomerName + y.CustomerSurname)
                .ToList();

            var ıntersectValues = cityValues.Intersect(cityValues2).ToList();

            return View(ıntersectValues);
        }

        public IActionResult CustomerCastExample()
        {
            var values = _context.Customers.ToList();
            ViewBag.v = values;
            return View();
        }

        public IActionResult CustomerListWithIndex()
        {
            var customers = _context.Customers
                .ToList()
                .Select((c, index) => new
                {
                    SıraNo = index + 1,
                    c.CustomerName,
                    c.CustomerSurname,
                    c.CustomerCity
                })
                .ToList();
            return View(customers);
        }
    }
}
