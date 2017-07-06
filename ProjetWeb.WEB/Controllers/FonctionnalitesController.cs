using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.DAL;
using ProjetWeb.BL;
using ProjetWeb.Model;

namespace ProjetWeb.WEB.Controllers
{
    public class FonctionnalitesController : Controller
    {
        //private Projet_GestionEntities db = new Projet_GestionEntities();
        private FonctionnaliteBL BLFonction = new FonctionnaliteBL();
        // GET: Fonctionnalites
        public ActionResult Index()
        {
            List<FonctionnaliteModel> fonction = new List<FonctionnaliteModel>();
            fonction = BLFonction.GetLesFonctionnalite();
            return View(fonction);
        }

        // GET: Fonctionnalites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FonctionnaliteModel fonctionnalite = BLFonction.GetUneFonctionnaliteById(id.GetValueOrDefault());
            if (fonctionnalite == null)
            {
                return HttpNotFound();
            }
            return View(fonctionnalite);
        }

        // GET: Fonctionnalites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fonctionnalites/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nom")] Fonctionnalite fonctionnalite)
        {
            if (ModelState.IsValid)
            {
                BLFonction.CreateFonction(fonctionnalite.nom);
                //db.Fonctionnalite.Add(fonctionnalite);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonctionnalite);
        }

        // GET: Fonctionnalites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FonctionnaliteModel fonctionnalite = BLFonction.GetUneFonctionnaliteById(id.GetValueOrDefault());
            if (fonctionnalite == null)
            {
                return HttpNotFound();
            }
            return View(fonctionnalite);
        }

        // POST: Fonctionnalites/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom")] Fonctionnalite fonctionnalite)
        {
            if (ModelState.IsValid)
            {
                BLFonction.ModifierFonctionnalite(fonctionnalite.id, fonctionnalite.nom);
                //db.Entry(fonctionnalite).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonctionnalite);
        }

        // GET: Fonctionnalites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLFonction.DeleteFonction(id.GetValueOrDefault());
            //Fonctionnalite fonctionnalite = db.Fonctionnalite.Find(id);
            if (BLFonction == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Fonctionnalites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLFonction.DeleteFonction(id);
            //Fonctionnalite fonctionnalite = db.Fonctionnalite.Find(id);
            //db.Fonctionnalite.Remove(fonctionnalite);
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
