using demandeEmploi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Repositories
{
    public class CompetenceRepository : IRepository<Competence>
    {
        private readonly AppDbContext _context;

        public CompetenceRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Competence template)
        {
            _context.Competences.Add(template);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Competence Get(int id)
        {
            return _context.Competences.Where(c => c.comptetenceId == id)
                .Include(c => c.candidats)
                .SingleOrDefault();
        }

        public IEnumerable<Competence> List()
        {
            return _context.Competences.ToList();
        }

        public IEnumerable<Competence> ListActif()
        {
            throw new NotImplementedException();
        }

        public void Update(Competence template)
        {
            throw new NotImplementedException();
        }
    }
}
