using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
