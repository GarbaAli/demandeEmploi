using demandeEmploi.Models;
using demandeEmploi.Repositories;
using demandeEmploi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demandeEmploi.Controllers
{
    public class CompetenceController : Controller
    {
        private readonly IRepository<Competence> _bd;

        public CompetenceController(IRepository<Competence> bd)
        {
            _bd = bd;
        }
        public IActionResult Index()
        {
            return View(_bd.List());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompetenceCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comp = new Competence()
                {
                    libelle = model.libelle
                };
                _bd.Add(comp);
                return RedirectToAction(nameof(Create));
            }
            return View(model);
        }
    }
}
