using demandeEmploi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Repositories
{
   public interface IRepository<Template>
    {
        void Add(Template template);
        void Update(Template template);
        IEnumerable<Template> List();
        IEnumerable<Template> ListActif();
        void Delete(int id);
        Template Get(int id);
    }
}
