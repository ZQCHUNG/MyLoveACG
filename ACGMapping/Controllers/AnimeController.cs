using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using ACGMapping.InfraStructure.ENum;
using ACGMapping.InfraStructure.Interface;
using ACGMapping.InfraStructure.Service;
using ACGMapping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ACGMapping.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IRepository<ACGMappingTable, int> _acgMappingRepository;
        private readonly IRepository<ACGBasicIntroductionTable, int> _acgBasicIntroductionRepository;
        private readonly IConfiguration _configuration;
        private readonly ElementGeneratorService _elementGeneratorService = new ElementGeneratorService();

        public AnimeController(IRepository<ACGMappingTable, int> acgMappingRepository,
            IRepository<ACGBasicIntroductionTable, int> acgBasicIntroductionRepository,
            IConfiguration configuration)
        {
            _acgMappingRepository = acgMappingRepository;
            _acgBasicIntroductionRepository = acgBasicIntroductionRepository;
            _configuration = configuration;
            _configuration = configuration;
        }

        public IActionResult Index(AnimeViewModel model)
        {
            //var names = _acgBasicIntroductionRepository.Find(o => o.Status != 99).Select(o => o.Name).Distinct().ToList();
            
            //model.Names = _elementGeneratorService.CreateListItems(names, "-1");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimeViewModel model)
        {
            await UploadFile(model);

            _acgBasicIntroductionRepository.Create(model);

            return RedirectToAction("Index");
        }

        private async Task UploadFile(AnimeViewModel model)
        {
            foreach (var file in model.FormFile)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(_configuration.GetValue<string>("ThumbnailFolderPath"), guid);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    model.ThumbnailPath = path;
                }
            }
        }

        public IActionResult GetImage(int id)
        {
            var target = _acgBasicIntroductionRepository.FindById(id);

            var image = System.IO.File.OpenRead(target.ThumbnailPath);

            return File(image, "image/jpg");
        }

        public IActionResult Detail(int id)
        {
            return View();
        }

        public string IsExistSameComicName(string name)
        {
            if (!_acgBasicIntroductionRepository.Find(o => o.Name == name).Any())
            {
                return EStatus.Success.ToString();
            }

            return EStatus.Failed.ToString();
        }
    }
}