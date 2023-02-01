using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemImporter.Functions
{
    public class MapItemsToNewModelFunction
    {
        [FunctionName("MapItemsToNewModel")]
        public void Run([BlobTrigger("items/{name}", Connection = "BlobConnectionString")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
