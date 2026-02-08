using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents.LayoutComponent
{
    public class _LayoutScriptsComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
