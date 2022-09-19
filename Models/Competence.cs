using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Models
{
    public class Competence
    {
        [Key]
        public int comptetenceId { get; set; }
        public string libelle { get; set; }
        public IEnumerable<Candidat> candidats { get; set; }
    }
}
