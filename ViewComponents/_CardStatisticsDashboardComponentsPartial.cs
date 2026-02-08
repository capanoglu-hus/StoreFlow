using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _CardStatisticsDashboardComponentsPartial :ViewComponent
    {
        private readonly StoreContext _context;

        public _CardStatisticsDashboardComponentsPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.totalCustomerCount = _context.Customers.Count(); // customer sayısını getirdi
            ViewBag.totalCategoryCount = _context.Categoryies.Count();
            ViewBag.totalProductCount = _context.Products.Count();
            ViewBag.avgCustomerBalance = _context.Customers.Average(x => x.CustomerBalance); // customer balancelerinin ortalamasını 
            ViewBag.totalOrderCount = _context.Orders.Count();
            ViewBag.sumOrderProductCount = _context.Orders.Sum(x => x.OrderCount); //kaç ürün alınmış
            return View();
        }
    }
}
