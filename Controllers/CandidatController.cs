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
    public class CandidatController : Controller
    {
        private readonly IRepository<Candidat> _bd;

        public CandidatController(IRepository<Candidat> bd)
        {
            _bd = bd;
        }
        public IActionResult Index()
        {
           var model =  _bd.List();
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            Candidat candidat = new Candidat();
            candidat = _bd.Get(id);
            if (candidat != null)
            {
                return View(candidat);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(CandidatCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Candidat candidat = new Candidat()
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    profession = model.profession,
                    DteNaissance = model.DteNaissance,
                    sexe = model.sexe,
                    service = model.service,
                    statut = true,
                    Experience = model.Experience,
                    statutFamilial = model.statutFamilial,
                    Age = model.Age,
                    Phone = model.Phone
                    
                };
                _bd.Add(candidat);
                return RedirectToAction("Detail", new { id = candidat.candidatId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _bd.Get(id);
            if (model != null)
            {
                var cand = new CandidatDeleteViewModel()
                {
                    candidatId = model.candidatId,
                    Nom = model.Nom,
                    Prenom = model.Prenom
                };
                return View(cand);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(CandidatDeleteViewModel model)
        {
            if (model.candidatId != 0)
            {
                var candidat = _bd.Get(model.candidatId);
                if (candidat != null)
                {
                    _bd.Delete(model.candidatId);
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _bd.Get(id);
            if (model != null)
            {
                var cand = new CandidatEditViewModel()
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    profession = model.profession,
                    DteNaissance = model.DteNaissance,
                    sexe = model.sexe,
                    service = model.service,
                    statut = true,
                    Experience = model.Experience,
                    statutFamilial = model.statutFamilial,
                    Age = model.Age,
                    Phone = model.Phone,
                    candidatId = model.candidatId,
                };
                return View(cand);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(CandidatEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cand = _bd.Get(model.candidatId);
                if (cand != null)
                {
                    cand.Nom = model.Nom;
                    cand.Prenom = model.Prenom;
                    cand.profession = model.profession;
                    cand.DteNaissance = model.DteNaissance;
                    cand.sexe = model.sexe;
                    cand.service = model.service;
                    cand.statut = true;
                    cand.Experience = model.Experience;
                    cand.statutFamilial = model.statutFamilial;
                    cand.Age = model.Age;
                    cand.Phone = model.Phone;
                    _bd.Update(cand);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
    }
}
