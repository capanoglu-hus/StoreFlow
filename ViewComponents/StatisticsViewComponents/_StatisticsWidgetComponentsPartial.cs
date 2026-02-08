using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetComponentsPartial:ViewComponent
    {
        private readonly StoreContext _context;
        public _StatisticsWidgetComponentsPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.categoryCount = _context.Categoryies.Count();
            ViewBag.productMaxprice = _context.Products.Max(x => x.ProductPrice);
            ViewBag.productMinprice = _context.Products.Min(x => x.ProductPrice);

            ViewBag.productMaxPriceProductName = _context.Products.Where(x => x.ProductPrice ==
            (_context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();

            ViewBag.productMinPriceProductName = _context.Products.Where(x => x.ProductPrice ==
            (_context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
            /*
             * where -> sorgulama istediğimiz özellikleri taşıyan veriyi bulur
             * select -> wherenin bulduğu veriyi satır olarak hafızaya alıp, onun istediğin özelliğini getirir.
             */


            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);
            ViewBag.AvgProductStock = Math.Round(_context.Products.Average(x => x.ProductStock),2);
            ViewBag.AvgProductPrice = Math.Round(_context.Products.Average(x => x.ProductPrice),2);
            /*
             * Math.Round -> decimal ayarlamaları için 
             */

            ViewBag.biggerPriceThen1000Product = _context.Products.Where(x => x.ProductPrice > 1000).Count();
            ViewBag.getIdis4ProductName = _context.Products.Where(x => x.ProductId == 4).Select(y=> y.ProductName).FirstOrDefault();
            ViewBag.StockCountBigger50andSmaller100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 1000).Count();
            return View();
        }
    }
}
