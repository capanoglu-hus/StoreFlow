using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _ActivitydashboardCompenentsPartial: ViewComponent
    {

        private readonly StoreContext _context;

        public _ActivitydashboardCompenentsPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Activities.ToList();
            return View(values);
        }
    }
}
