using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ItemImporter.Common.Models
{
    public class ConvertedItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Handle { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Vendor { get; set; }
        public string Type { get; set; }
        public List<string> Tags { get; set; }
        public int Price { get; set; }
        public bool Stock { get; set; }      
    }
}
