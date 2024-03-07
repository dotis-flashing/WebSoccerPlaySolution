using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class AppConfiguration
    {
        public string DatabaseConnection { get; set; }
        public string AzureBlobStorage { get; set; }
        public string ContainerName { get; set; }
    }
}
