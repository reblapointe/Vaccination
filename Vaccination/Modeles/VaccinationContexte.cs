using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vaccination.Modeles
{

    public class VaccinationContext : DbContext
    {
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Vaccin> Vaccins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Vaccination;Trusted_Connection=True;");

    }
}