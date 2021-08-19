using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petshop.Domain.Entities;
using Petshop.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Controllers
{
    public class PetController : Controller
    {
        private readonly ContextPetShop _db;

        public PetController(ContextPetShop db)
        {
            _db = db;
        }

        // GET: PetController
        public ActionResult Index()
        {
            return View(_db.Pets.ToList());
        }

        // GET: PetController/Details/5
        public ActionResult Details(int id)
        {
            var pet = _db.Pets.Find(id);
            return View(pet);
        }

        // GET: PetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pets pet)
        {
            try
            {
                _db.Add(pet);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return View();
            }
        }

        // GET: PetController/Edit/5
        public ActionResult Edit(int id)
        {
            var pet = _db.Pets.Find(id);
            return View(pet);
        }

        // POST: PetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pets pet)
        {
            try
            {
                var novoPet = _db.Pets.Find(id);
                novoPet.Nome = pet.Nome;
                novoPet.Raca = pet.Raca;
                novoPet.Tipo = pet.Tipo;
                novoPet.Idade = pet.Idade;

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetController/Delete/5
        public ActionResult Delete(int id)
        {
            var pet = _db.Pets.Find(id);
            return View(pet);
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pets pet)
        {
            try
            {
                var petExiste = _db.Pets.Find(id);
                _db.Remove(petExiste);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
