using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.ViewModels
{
    public class CandidatCreateViewModel
    {
        [Key]
        public int candidatId { get; set; }
        [Required]
        [MinLength(3)]
        public string Nom { get; set; }
        [Required]
        [MinLength(3)]
        public string Prenom { get; set; }
        [Required]
        public string profession { get; set; }
        [Required]
        public string sexe { get; set; }
        [Required]
        public DateTime DteNaissance { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string statutFamilial { get; set; }
        public bool statut { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        [MinLength(7)]
        public string Phone { get; set; }
        public string service { get; set; }
    }
}
