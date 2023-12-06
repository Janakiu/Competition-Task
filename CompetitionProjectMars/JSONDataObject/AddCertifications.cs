using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CompetitionProjectMars.JSONDataObject
{
    public class AddCertifications
    {
        public string CertificationName { get; set; } = string.Empty;
        public string Certifiedfrom { get; set; } = string.Empty;
        public string year { get; set; } = string.Empty;



    }
}
