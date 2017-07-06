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
    public class ProfilsController : Controller
    {
        //private Projet_GestionEntities db = new Projet_GestionEntities();
        private ProfilBL BLprofil = new ProfilBL();
        // GET: Profils
        public ActionResult Index()
        {
            List<ProfilModel> profil = new List<ProfilModel>();
            profil = BLprofil.GetLesProfil();
            return View(profil);
        }

        // GET: Profils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfilModel profil = BLprofil.GetUnProfilById(id.GetValueOrDefault());
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // GET: Profils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profils/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nom")] ProfilModel profil)
        {
            if (ModelState.IsValid)
            {
                BLprofil.CreateProfil(profil.nom);
                //db.Profil.Add(profil);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profil);
        }

        // GET: Profils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfilModel profil = BLprofil.GetUnProfilById(id.GetValueOrDefault());
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // POST: Profils/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom")] Profil profil)
        {
            if (ModelState.IsValid)
            {
                BLprofil.ModifierProfil(profil.id, profil.nom);
                //db.Entry(profil).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profil);
        }

        //public ActionResult afficherProfilsId(int id)
        //{
        //        @{
        //        List<SelectListItem>
        //          listItems = new List<SelectListItem>();
        //        listItems.Add(new SelectListItem
        //        {
        //            Text = "Administrateur",
        //            Value = "1"
        //        });
        //        listItems.Add(new SelectListItem
        //        {
        //            Text = "Lecteur",
        //            Value = "2"
        //        });
        //        listItems.Add(new SelectListItem
        //        {
        //            Text = "Utilisateur",
        //            Value = "3"
        //        });
        //    }

        //    return View();
        //}

        // GET: Profils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLprofil.DeleteProfil(id.GetValueOrDefault());
            //Profil profil = db.Profil.Find(id);
            if (BLprofil == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Profils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLprofil.DeleteProfil(id);
            //Profil profil = db.Profil.Find(id);
            //db.Profil.Remove(profil);
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
