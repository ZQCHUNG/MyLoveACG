using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ACGMapping.InfraStructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ACGMapping.Models;

namespace ACGMapping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<ACGBasicIntroductionTable, int> _acgBasicRepository;

        public HomeController(ILogger<HomeController> logger,
            IRepository<ACGBasicIntroductionTable,int> acgBasicRepository)
        {
            _logger = logger;
            _acgBasicRepository = acgBasicRepository;
        }

        public IActionResult Index()
        {
            var model = _acgBasicRepository.AllEntities().ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
