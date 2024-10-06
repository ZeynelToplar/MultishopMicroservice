using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
