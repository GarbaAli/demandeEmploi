using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.ViewModels
{
    public class CandidatDeleteViewModel
    {
        public int candidatId { get; set; }
        [Required]
        [MinLength(3)]
        public string Nom { get; set; }
        [Required]
        [MinLength(3)]
        public string Prenom { get; set; }
    }
}
