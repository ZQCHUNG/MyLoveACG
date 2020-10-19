using ACGMapping.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACGMapping.Controllers
{
    public class AnimeController : Controller
    {
        public IActionResult Create(ACGInfoModel model)
        {
            return View();
        }
    }
}