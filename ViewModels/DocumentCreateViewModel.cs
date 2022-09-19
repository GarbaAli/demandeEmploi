using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.ViewModels
{
    public class DocumentCreateViewModel
    {
        [Key]
        public int documentId { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int candidat { get; set; }
        [Required]
        public IFormFile fichier { get; set; }
    }
}
