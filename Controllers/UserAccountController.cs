using Microsoft.AspNetCore.Mvc;
using MVC_Routing.Models.InputModels;
using MVC_Routing.Models.ViewModels;

namespace MVC_Routing.Controllers
{
    [Route("Account")]
    public class UserAccountController : Controller
    {
        [Route("User")]
        public IActionResult Index()
        {
            var userInfo = new UserInfoVM
            {
                Email = "sinaemre@bilgeadam.com",
                UserName = "Sina Emre",
                InformationText = "Software Trainer",
                Roles = new List<string> { "Yazılımcı", "Elektrik-Elektronik Mühendisi", "Yazılım Eğitmeni", "Robotik Kodlama Eğitmeni" }
            };

            return View(userInfo);
        }

        //Parametreli Route Kullanımı
        [Route("Parameters/{email}/{userName}/{informationText}")]
        public IActionResult Parameters(string email, string userName, string informationText)
        {
            UserInfoVM userInfo = new UserInfoVM
            {
                Email = email,
                InformationText = informationText,
                UserName = userName,
                Roles = new List<string> { "Rol Yok!" }
            };

            return View(userInfo);
        }

        //View'in açılmasını sağlayan kısım HttpGet kısmıdır. Bir action'un attribute'üne birşey yazmazsanız default olarak HttpGet'dir.
        [HttpGet("UserCreate")]
        public IActionResult UserCreate()
        {
            return View();
        }

        //Kullanıcıdan gelen veriyi(form verisi) Back-end'e gönderen kısım ise HttpPost kısmıdır.
        [HttpPost("UserCreate")]
        public IActionResult UserCreate(UserFormIM model)
        {
            //Geçici mesajlar için kullanır.
            TempData["Success"] = "Kayıt Yapıldı";
            
            //RedirectToAction() => İşlem bittikten farklı controller'ın action'ına ya da aynı controller'ın farklı action'ına yönlendirme yapar.
            return RedirectToAction("Index","Home");
        }
    }
}
