using Microsoft.AspNetCore.Mvc;
using MVC_Routing.Models.ViewModels;

namespace MVC_Routing.Controllers
{
    public class DynamicController : Controller
    {
        public IActionResult Detail(string name, string id)
        {
            var dynamicObject = new DynamicVM
            {
                Name = name,
                Id = id
            };

            return View(dynamicObject);
        }
    }
}
