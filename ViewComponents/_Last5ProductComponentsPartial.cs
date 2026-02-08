using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _Last5ProductComponentsPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _Last5ProductComponentsPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Products.OrderBy(x => x.ProductId)
                .ToList().SkipLast(5)
                .ToList().TakeLast(7)
                .ToList();
            return View(values);
        }
    }
}
