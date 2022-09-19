using demandeEmploi.Models;
using demandeEmploi.Repositories;
using demandeEmploi.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Candidat> _bdCand;
        private readonly IWebHostEnvironment _hostingEnironment;
        private readonly AppDbContext _context;
        public DocumentController(AppDbContext context, IRepository<Document> bd, IRepository<Candidat> bdCand, IWebHostEnvironment hostingEnironment)
        {
            _bd = bd;
            _bdCand = bdCand;
            _hostingEnironment = hostingEnironment;
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Documents.Include(d=>d.candidatLink).ToList());
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.candidat = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(DocumentCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                Candidat cand = _bdCand.Get(model.candidat);
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
                    candidatLink = cand
                };
                _bd.Add(doc);
                return RedirectToAction("Create", new { id = model.candidat });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _bd.Get(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Document model)
        {
            if (model.DocumentId != 0)
            {
                var doc = _bd.Get(model.DocumentId);
                if (doc != null)
                {
                    _bd.Delete(model.DocumentId);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
    }
}
