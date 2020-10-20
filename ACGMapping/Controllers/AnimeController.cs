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

        public AnimeController(IRepository<ACGMappingTable, int> acgMappingRepository)
        {
            _acgMappingRepository = acgMappingRepository;
        }

        public IActionResult Index(AnimeViewModel model)
        {
            var elementGeneratorService = new ElementGeneratorService();

            var names = _acgMappingRepository.Find(o => o.Status != 99).Select(o => o.Name).Distinct().ToList();
            
            model.Names = elementGeneratorService.CreateListItems(names, "-1");

            return View(model);
        }

        public IActionResult Create(ACGMappingTable model)
        {
            _acgMappingRepository.Create(model);

            return RedirectToAction("Index");
        }
    }
}