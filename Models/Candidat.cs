using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Models
{
    public class Candidat
    {
        [Key]
        public int candidatId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string profession { get; set; }
        public string sexe { get; set; }
        public DateTime DteNaissance { get; set; }
        public int Age { get; set; }
        public string statutFamilial { get; set; }
        public bool statut { get; set; }
        public int Experience { get; set; }
        public string Phone { get; set; }
        public string service { get; set; }
        public IEnumerable<Document> documents { get; set; }
        public IEnumerable<Competence> competences { get; set; }
    }
}
