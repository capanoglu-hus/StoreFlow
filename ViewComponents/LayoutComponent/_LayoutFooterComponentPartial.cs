using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents.LayoutComponent
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
