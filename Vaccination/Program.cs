using Vaccination.Modeles;

namespace Vaccination
{
    internal class Program
    {
        static void Main(string[] _)
        {
            using (VaccinationContext context = new())
            {
                if (!context.Vaccins.Any())
                {
                    Vaccin pfizer = new() { Nom = "Pfizer-BioNTech" };
                    Vaccin moderna = new() { Nom = "Moderna" };
                    Vaccin astra = new() { Nom = "AstraZeneca" };
                    context.Vaccins.AddRange(pfizer, moderna);
                    context.SaveChanges();
                }

                Vaccin? m = context.Vaccins.FirstOrDefault(v => v.Nom.Contains("Moderna"));
                Vaccin? p = context.Vaccins.FirstOrDefault(v => v.Nom.Contains("Pfizer"));

                Dose dose1Mylene = new()
                {
                    Date = new DateTime(2021, 06, 15),
                    NAMPatient = "LAPM12345678",
                    VaccinId = m?.VaccinId,
                    Vaccin = m
                };

                Dose dose2Mylene = new()
                {
                    Date = DateTime.Today,
                    NAMPatient = "LAPM12345678",
                    VaccinId = m?.VaccinId,
                    Vaccin = m
                };
                Dose dose1Gaston = new()
                {
                    Date = new DateTime(2021, 8, 22),
                    NAMPatient = "BHEG12345678",
                    VaccinId = p?.VaccinId,
                    Vaccin = p
                };

                context.Doses.Add(dose1Mylene); // Ajout de doses
                context.Doses.Add(dose2Mylene);
                context.Doses.Add(dose1Gaston);
                context.SaveChanges();
                ImprimerImmunisations(context.Doses);

               // context.Remove(dose1Gaston);    // Retrait d'une dose
                dose1Mylene.Vaccin = p;         // Changement d'une dose
                context.SaveChanges();


                // Ajouter des cas de Covid-19
                var covidCase1 = new Covid19
                {
                    Date = DateTime.Now.AddDays(-20),
                    NAMPatient = "BHEG12345678",
                    NomVariant = "Delta",
                    EstSevere = false
                };

                var covidCase2 = new Covid19
                {
                    Date = DateTime.Now.AddDays(-15),
                    NAMPatient = "LAPM12345678",
                    NomVariant = "Omicron",
                    EstSevere = true
                };

                context.CasCovid.AddRange(covidCase1, covidCase2);
                context.SaveChanges();

                // Vérifier les données enregistrées
                
                ImprimerImmunisations(context.Immunisations);

                Console.WriteLine("Entrez un Numéro d'assurance maladie");
                string nam = Console.ReadLine()??"";
                var passeport = context.Immunisations.Where(d => d.NAMPatient == nam);
                Console.WriteLine($"{nam} a reçu {passeport.Count()} immunisation(s) :");
                ImprimerImmunisations(passeport);
            }
            Console.ReadKey();
        }

        public static void ImprimerImmunisations(IQueryable<Immunisation> immunisations)
        {
            Console.WriteLine("Immunisation :");
            foreach (Immunisation i in immunisations)
                Console.WriteLine(i);
        }
    }
}
