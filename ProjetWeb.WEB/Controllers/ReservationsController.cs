using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.Model;
using ProjetWeb.BL;

namespace ProjetWeb.WEB.Controllers
{
    public class ReservationsController : Controller
    {
        //private Projet_GestionEntities db = new Projet_GestionEntities();
        private ReservationBL BLResa = new ReservationBL();

        // GET: Reservations
        public ActionResult Index()
        {
            // On check si l'utilisateur est connecté
            if (Session["Utilisateur"] == null)
            {
                return RedirectToAction("Index","Home");
            }

            List<ReservationModel> reservation = new List<ReservationModel>();
            reservation = BLResa.GetLesReservation();
            //var reservation = db.Reservation.Include(r => r.Utilisateur);
            return View(reservation);
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservation = BLResa.GetUneReservationById(id.GetValueOrDefault());
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //GET: Reservations/Create
        public ActionResult Create()
        {
            //ViewBag.utilisateur_id = new SelectList(db.Utilisateur, "id", "nom");
            return View();
        }

        // POST: Reservations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,utilisateur_id,date_resa,purge")] ReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                BLResa.CreateReservation(reservation.id,reservation.utilisateur_id,reservation.date_resa,reservation.purge);
                //db.Reservation.Add(reservation);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.utilisateur_id = new SelectList(db.Utilisateur, "id", "nom", reservation.utilisateur_id);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservation = BLResa.GetUneReservationById(id.GetValueOrDefault());
            if (reservation == null)
            {
                return HttpNotFound();
            }
            //ViewBag.utilisateur_id = new SelectList(db.Utilisateur, "id", "nom", reservation.utilisateur_id);
            return View(reservation);
        }

        //// POST: Reservations/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,utilisateur_id,date_resa,purge")] ReservationModel reservation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        BLResa.ModifierReservation
        //        //db.Entry(reservation).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.utilisateur_id = new SelectList(db.Utilisateur, "id", "nom", reservation.utilisateur_id);
        //    return View(reservation);
        //}

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLResa.DeleteReservation(id.GetValueOrDefault());
            //Reservation reservation = db.Reservation.Find(id);
            if (BLResa == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLResa.DeleteReservation(id);
            //Reservation reservation = db.Reservation.Find(id);
            //db.Reservation.Remove(reservation);
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
