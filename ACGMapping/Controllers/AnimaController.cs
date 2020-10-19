using Microsoft.AspNetCore.Mvc;

namespace ACGMapping.Controllers
{
    public class AnimaController : Controller
    {
        public IActionResult Create(Anima model)
        {
            return View();
        }
    }

    public class Anima
    {

    }
}