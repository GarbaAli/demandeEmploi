﻿using demandeEmploi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Repositories
{
    public class DocumentRepository : IRepository<Document>
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Document template)
        {
            _context.Add(template);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Document Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> List()
        {
            return _context.Documents.ToList();
        }

        public IEnumerable<Document> ListActif()
        {
            throw new NotImplementedException();
        }

        public void Update(Document template)
        {
            throw new NotImplementedException();
        }
    }
}