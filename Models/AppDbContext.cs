using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Competence> Competences { get; set; }
    }
}
