using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vaccination.Modeles
{
    public class Vaccin
    {
        public int VaccinId { get; set; }
        public required string Nom { get; set; }

        public override string ToString()
        {
            return $"{VaccinId}-{Nom}";
        }
    }
}