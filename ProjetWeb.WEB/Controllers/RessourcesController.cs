﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;

namespace ProjetWeb.WEB.Controllers
{
    public class RessourcesController : Controller
    {
        //private Projet_GestionEntities db = new Projet_GestionEntities();
        private RessourceBL BLRessource = new RessourceBL();

        // GET: Ressources
        public ActionResult Index()
        {
            List<RessourceModel> ressource = new List<RessourceModel>();
            //var ressource = db.Ressource.Include(r => r.Type);
            return View(ressource);
        }

        // GET: Ressources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RessourceModel ressource = BLRessource.GetUneRessourceById(id.GetValueOrDefault());
            if (ressource == null)
            {
                return HttpNotFound();
            }
            return View(ressource);
        }

        // GET: Ressources/Create
        public ActionResult Create()
        {
            //ViewBag.type_id = new SelectList(db.Type, "id", "nom");
            return View();
        }

        // POST: Ressources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nom,description,date_achat,qr_code,typeRes")] RessourceModel ressource)
        {
            if (ModelState.IsValid)
            {
                //db.Ressource.Add(ressource);
                //db.SaveChanges();
                BLRessource.CreateRessource(ressource.nom, ressource.description, ressource.date_achat, ressource.qr_code, ressource.typeRes);
                return RedirectToAction("Index");
            }

            //ViewBag.type_id = new SelectList(db.Type, "id", "nom", ressource.type_id);
            return View(ressource);
        }

        // GET: Ressources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RessourceModel ressource = BLRessource.GetUneRessourceById(id.GetValueOrDefault());
            if (ressource == null)
            {
                return HttpNotFound();
            }
            //ViewBag.type_id = new SelectList(db.Type, "id", "nom", ressource.type_id);
            return View(ressource);
        }

        // POST: Ressources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type_id,nom,dispo,description,date_achat,qr_code,purge")] RessourceModel ressource)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ressource).State = EntityState.Modified;
                //db.SaveChanges();
                BLRessource.ModifierRessource(ressource.id, ressource.type_id, ressource.nom, ressource.dispo, ressource.description, ressource.date_achat, ressource.qr_code, ressource.purge);

                return RedirectToAction("Index");
            }
            //ViewBag.type_id = new SelectList(db.Type, "id", "nom", ressource.type_id);
            return View(ressource);
        }

        // GET: Ressources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLRessource.DeleteRessource(id.GetValueOrDefault());
            if (BLRessource == null)
            {
                return HttpNotFound();
            }
            return View(BLRessource);
        }

        // POST: Ressources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLRessource.DeleteRessource(id);
            //Ressource ressource = db.Ressource.Find(id);
            //db.Ressource.Remove(ressource);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
