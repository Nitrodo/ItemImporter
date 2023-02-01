using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemImporter.Common.Models
{
    public class FileWrapper
    {
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public Stream? Stream { get; set; }
    }
}
