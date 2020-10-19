using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

namespace ACGMapping.Models
{
    public class ACGInfoModel
    {
        [DisplayName("流水號")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [DisplayName("自訂名稱")]
        public string Name { get; set; }
        [DisplayName("Comic集數")]
        public int ComicEpisode { get; set; } 
        [DisplayName("Anime集數")]
        public int AnimeEpisode { get; set; }

        [DisplayName("AnimeSeason")]
        public int AnimeSeason { get; set; } 
        [DisplayName("Novel集數")]
        public int NovelEpisode { get; set; } 
        [DisplayName("發行時間")]
        public DateTime PublicTime { get; set; } 
        [DisplayName("建立時間")]
        public string CreateDateTime { get; set; } 
        [DisplayName("簡介")]
        public string Profile { get; set; } 
        [DisplayName("上傳縮圖")]
        public string ThumbnailPath { get; set; } 
        public int Status { get; set; } 
    }
}