using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination.Modeles
{

    public class Dose : Immunisation
    {
        public int? VaccinId { get; set; }
        public Vaccin? Vaccin { get; set; }

        public override string ToString()
        {
            return $"Immunisation #{ImmunisationId} : {Vaccin}EC administré le {Date} à {NAMPatient}";
        }
    }

}
