using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACGMapping.Models
{
    public class AnimeViewModel : ACGBasicIntroductionTable
    {
        public AnimeViewModel()
        {
            Names = new List<SelectListItem>();
        }
        public IEnumerable<SelectListItem> Names { get; set; }

        [DisplayName("已存在名稱")]
        public string ExistNames { get; set; }

        [DisplayName("附檔")]
        public List<IFormFile> FormFile { get; set; }
    }
}