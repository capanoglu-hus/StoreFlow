using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _ChartComplenetsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
