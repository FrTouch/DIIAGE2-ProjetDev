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
    public class Ligne_resaController : Controller
    {
        private Projet_GestionEntities db = new Projet_GestionEntities();

        // GET: Ligne_resa
        public ActionResult Index()
        {
            var ligne_resa = db.Ligne_resa.Include(l => l.Reservation).Include(l => l.Ressource);
            return View(ligne_resa.ToList());
        }

        // GET: Ligne_resa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ligne_resa ligne_resa = db.Ligne_resa.Find(id);
            if (ligne_resa == null)
            {
                return HttpNotFound();
            }
            return View(ligne_resa);
        }

        // GET: Ligne_resa/Create
        public ActionResult Create()
        {
            ViewBag.reservation_id = new SelectList(db.Reservation, "id", "id");
            ViewBag.ressource_id = new SelectList(db.Ressource, "id", "nom");
            return View();
        }

        // POST: Ligne_resa/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reservation_id,ressource_id,date_debut,date_fin,purge")] Ligne_resa ligne_resa)
        {
            if (ModelState.IsValid)
            {
                db.Ligne_resa.Add(ligne_resa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.reservation_id = new SelectList(db.Reservation, "id", "id", ligne_resa.reservation_id);
            ViewBag.ressource_id = new SelectList(db.Ressource, "id", "nom", ligne_resa.ressource_id);
            return View(ligne_resa);
        }

        // GET: Ligne_resa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ligne_resa ligne_resa = db.Ligne_resa.Find(id);
            if (ligne_resa == null)
            {
                return HttpNotFound();
            }
            ViewBag.reservation_id = new SelectList(db.Reservation, "id", "id", ligne_resa.reservation_id);
            ViewBag.ressource_id = new SelectList(db.Ressource, "id", "nom", ligne_resa.ressource_id);
            return View(ligne_resa);
        }

        // POST: Ligne_resa/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reservation_id,ressource_id,date_debut,date_fin,purge")] Ligne_resa ligne_resa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligne_resa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reservation_id = new SelectList(db.Reservation, "id", "id", ligne_resa.reservation_id);
            ViewBag.ressource_id = new SelectList(db.Ressource, "id", "nom", ligne_resa.ressource_id);
            return View(ligne_resa);
        }

        // GET: Ligne_resa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ligne_resa ligne_resa = db.Ligne_resa.Find(id);
            if (ligne_resa == null)
            {
                return HttpNotFound();
            }
            return View(ligne_resa);
        }

        // POST: Ligne_resa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ligne_resa ligne_resa = db.Ligne_resa.Find(id);
            db.Ligne_resa.Remove(ligne_resa);
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
