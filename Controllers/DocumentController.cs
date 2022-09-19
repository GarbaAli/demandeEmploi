using demandeEmploi.Models;
using demandeEmploi.Repositories;
using demandeEmploi.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IRepository<Document> _bd;
        private readonly IWebHostEnvironment _hostingEnironment;
        public DocumentController(IRepository<Document> bd, IWebHostEnvironment hostingEnironment)
        {
            _bd = bd;
            _hostingEnironment = hostingEnironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            ViewBag.candidat = id;
            return View();
        }

        public IActionResult Create(DocumentCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.fichier != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnironment.WebRootPath, "Documents");
                    uniqueFileName = Guid.NewGuid() + "_" + model.fichier.FileName;
                    string path = Path.Combine(uploadsFolder, uniqueFileName);
                    model.fichier.CopyTo(new FileStream(path, FileMode.Create));
                }

                Document doc = new Document()
                {
                    type = model.type,
                    fichier = uniqueFileName,
                };
                _bd.Add(doc);
                return RedirectToAction("Create", new { id = model.candidat });
            }
            return View();
        }
    }
}
