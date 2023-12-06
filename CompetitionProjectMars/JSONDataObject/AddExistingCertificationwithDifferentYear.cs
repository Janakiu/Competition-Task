using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionProjectMars.JSONDataObject
{
    public class AddExistingCertificationwithDifferentYear
    {
        public string CertificationName { get; set; }
        public string CertifiedFrom { get; set; }
        public string Year { get; set; }
        public string CertificationNameNew { get; set; }
        public string CertifiedFromNew { get; set; }
        public string YearNew { get; set; }

        public string PopUpMessage { get; set; } = string.Empty;
    }
}
