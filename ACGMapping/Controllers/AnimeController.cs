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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimeViewModel model)
        {
            await UploadFile(model);

            _acgBasicIntroductionRepository.Create(model);

            return RedirectToAction("Index", "Home");
        }

        private async Task UploadFile(AnimeViewModel model)
        {
            foreach (var file in model.FormFile)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(_configuration.GetValue<string>("ThumbnailFolderPath"), guid);
                    await using (var stream = new FileStream(path, FileMode.Create))
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

        public IActionResult Detail(int? id)
        {
            var model = new AnimeDetailViewModel();

            if (id != null)
            {
                var targetTable = _acgBasicIntroductionRepository.FindById(id.Value);

                if (targetTable == null)
                {
                    RedirectToAction("Index", "Home");
                }

                model.AnimeViewModel = targetTable;
            }
            else
            {
                RedirectToAction("Index", "Home");
            }

            model.AcgMappingTables = _acgMappingRepository.AllEntities().ToList();

            return View(model);
        }

        public string IsExistSameComicName(string name)
        {
            if (!_acgBasicIntroductionRepository.Find(o => o.Name == name).Any())
            {
                return EStatus.Success.ToString();
            }

            return EStatus.Failed.ToString();
        }

        public IActionResult FillComicMapping(FillComicViewModel model)
        {
            return View(model);
        }

        public IActionResult AddComicMappingInfo(FillComicViewModel model)
        {
            _acgMappingRepository.Create(model);

            return RedirectToAction("Detail", new { id = model.BasicIntroductionId });
        }
    }
}