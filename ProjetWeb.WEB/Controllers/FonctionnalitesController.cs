using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.DAL;

namespace ProjetWeb.WEB.Controllers
{
    public class FonctionnalitesController : Controller
    {
        private Projet_GestionEntities db = new Projet_GestionEntities();

        // GET: Fonctionnalites
        public ActionResult Index()
        {
            return View(db.Fonctionnalite.ToList());
        }

        // GET: Fonctionnalites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonctionnalite fonctionnalite = db.Fonctionnalite.Find(id);
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
        public ActionResult Create([Bind(Include = "id,nom")] Fonctionnalite fonctionnalite)
        {
            if (ModelState.IsValid)
            {
                db.Fonctionnalite.Add(fonctionnalite);
                db.SaveChanges();
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
            Fonctionnalite fonctionnalite = db.Fonctionnalite.Find(id);
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
                db.Entry(fonctionnalite).State = EntityState.Modified;
                db.SaveChanges();
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
            Fonctionnalite fonctionnalite = db.Fonctionnalite.Find(id);
            if (fonctionnalite == null)
            {
                return HttpNotFound();
            }
            return View(fonctionnalite);
        }

        // POST: Fonctionnalites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fonctionnalite fonctionnalite = db.Fonctionnalite.Find(id);
            db.Fonctionnalite.Remove(fonctionnalite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
