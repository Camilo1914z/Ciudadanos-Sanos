using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Data
{
    public class CentrosaludContext : DbContext
    {
        public CentrosaludContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }    
        public DbSet<Patiente> Patientes { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
