using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models
{
    [Serializable()]
    public class SearchResult
    {
        public string Id { get; set; }
        public string StandNum { get; set; }
        public string Cn { get; set; }
        public string En { get; set; }
        public string Isd { get; set; }
        public string Efd { get; set; }
        public string ICS { get; set; }
        public string CCS { get; set; }
        public string GBN { get; set; }
        public string DraftingUnit { get; set; }
        public string TableName { get; set; }
        public string StandStatus { get; set; }
        public string CategoryCode { get; set; }

    }
}
