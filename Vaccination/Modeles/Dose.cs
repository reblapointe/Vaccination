using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination.Modeles
{

    public class Dose
    {
        public int DoseId { get; set; }
        public DateTime Date { get; set; }
        public required string NAMPatient { get; set; }

        public int? VaccinId { get; set; }
        public Vaccin? Vaccin { get; set; }

        public override string ToString()
        {
            return $"Dose #{DoseId} ({Vaccin}), administré le {Date} à {NAMPatient}";
        }
    }

}
