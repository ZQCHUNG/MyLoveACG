using System.Collections.Generic;

namespace ACGMapping.Models
{
    public class AnimeDetailViewModel
    {
        public AnimeDetailViewModel()
        {
            AnimeViewModel = new ACGBasicIntroductionTable();
            AcgMappingTables = new List<ACGMappingTable>();
        }
        public ACGBasicIntroductionTable AnimeViewModel { get; set; }

        public List<ACGMappingTable> AcgMappingTables { get; set; }
    }
}