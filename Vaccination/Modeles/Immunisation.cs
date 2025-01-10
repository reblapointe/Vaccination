using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination.Modeles
{
    public abstract class Immunisation
    {
        public int ImmunisationId { get; set; }
        public DateTime Date { get; set; }
        public required string NAMPatient { get; set; }
    }
}
