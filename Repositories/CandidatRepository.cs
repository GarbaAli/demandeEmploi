using demandeEmploi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Repositories
{
    public class CandidatRepository : IRepository<Candidat>
    {
        private readonly AppDbContext _context;

        public CandidatRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Candidat template)
        {
            _context.Candidats.Add(template);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cand = Get(id);
            _context.Candidats.Remove(cand);
        }

        public Candidat Get(int id)
        {
            return _context.Candidats.Find(id);
        }

        public IEnumerable<Candidat> List()
        {
            return _context.Candidats.Include(c => c.competences).ToList();
        }

        public IEnumerable<Candidat> ListActif()
        {
            return _context.Candidats.Where(c => c.statut == true)
                .Include(c => c.competences)
                .ToList();
        }

        public void Update(Candidat template)
        {
            _context.Candidats.Update(template);
            _context.SaveChanges();
        }
    }
}
