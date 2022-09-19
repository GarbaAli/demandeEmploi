using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.ViewModels
{
    public class CompetenceCreateViewModel
    {
        [Key]
        public int comptetenceId { get; set; }
        [Required]
        [Display(Name ="Libelle de la competence")]
        public string libelle { get; set; }
    }
}
