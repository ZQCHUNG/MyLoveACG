using System.Collections.Generic;
using System.Linq;
using ACGMapping.InfraStructure.Interface;
using ACGMapping.InfraStructure.Service;
using ACGMapping.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACGMapping.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IRepository<ACGMappingTable, int> _acgMappingRepository;
        private readonly IRepository<ACGBasicIntroductionTable, int> _acgBasicIntroductionRepository;
        private readonly ElementGeneratorService _elementGeneratorService = new ElementGeneratorService();

        public AnimeController(IRepository<ACGMappingTable, int> acgMappingRepository,
            IRepository<ACGBasicIntroductionTable, int> acgBasicIntroductionRepository
            )
        {
            _acgMappingRepository = acgMappingRepository;
            _acgBasicIntroductionRepository = acgBasicIntroductionRepository;
        }

        public IActionResult Index(AnimeViewModel model)
        {
            var names = _acgMappingRepository.Find(o => o.Status != 99).Select(o => o.Name).Distinct().ToList();
            
            model.Names = _elementGeneratorService.CreateListItems(names, "-1");

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AnimeViewModel model)
        {
            _acgBasicIntroductionRepository.Create(model);

            return RedirectToAction("Index");
        }
    }
}