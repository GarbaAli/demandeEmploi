using demandeEmploi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.ViewModels
{
    public class DocumentViewModel
    {
        [Key]
        public int DocumentId { get; set; }
        public string type { get; set; }
        public string fichier { get; set; }
        public Candidat candidat { get; set; }
    }
}
