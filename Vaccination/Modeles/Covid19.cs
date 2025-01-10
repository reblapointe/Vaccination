using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination.Modeles
{
    public class Covid19 : Immunisation
    {
        public required string NomVariant { get; set; } // Exemple : Delta, Omicron
        public bool EstSevere { get; set; }

        public override string ToString()
        {
            return $"Immunisation #{ImmunisationId} : Covid-19 {NomVariant}{(EstSevere ? " (Sévère)" : "")} pour {NAMPatient} le {Date}";

        }
    }
}

