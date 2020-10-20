using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACGMapping.Models
{
    public class ACGMappingTable
    {
        [DisplayName("流水號")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [DisplayName("自訂名稱")]
        public string Name { get; set; }

        [DisplayName("Comic話數")]
        public string ComicEpisode { get; set; } 
        [DisplayName("Anime集數")]
        public string AnimeEpisode { get; set; }

        [DisplayName("AnimeSeason")]
        public string AnimeSeason { get; set; } 
        [DisplayName("Novel集數")]
        public string NovelEpisode { get; set; } 

        [DisplayName("出版日期")]
        public DateTime PublicTime { get; set; } 

        [DisplayName("建立時間")]
        public DateTime CreateDateTime { get; set; } 

        [DisplayName("簡介")]
        public string Profile { get; set; } 
        [DisplayName("上傳縮圖")]
        public string ThumbnailPath { get; set; } 
        public int Status { get; set; } 
    }
}