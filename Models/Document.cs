using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string type { get; set; }
        public string fichier { get; set; }
    }
}
