using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACGMapping.Models
{
    public class ACGBasicIntroductionTable
    {
        [DisplayName("流水號")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [DisplayName("自訂名稱")]
        public string Name { get; set; }

        [DisplayName("建立時間")]
        public DateTime CreateDateTime { get; set; } 

        [DisplayName("簡介")]
        public string Profile { get; set; } 

        [DisplayName("上傳縮圖")]
        public string ThumbnailPath { get; set; } 
        public int Status { get; set; } 
    }
}