using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data.Identity;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<MedicalCard> MedicalCards { get; set; }
        public DbSet<ChronicIllness> ChronicIllnesses { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
    }
}