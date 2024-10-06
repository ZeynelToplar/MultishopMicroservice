using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
