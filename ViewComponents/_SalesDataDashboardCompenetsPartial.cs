using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _SalesDataDashboardCompenetsPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _SalesDataDashboardCompenetsPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var val = _context.Orders.ToList(); // hepsini getirir
            var values = _context.Orders.OrderByDescending(z => z.OrderId).Include(x => x.Customer).Include(y=> y.Product).Take(5).ToList();
            /*
             * OrderByDescending -> Idleri büyükten küçüge sıraladı.
             * Include -> join işlemini yapıyor.
             * Take -> listeden ilk 5 tane aldı.
             */
            return View(values);
        }
    }
}
