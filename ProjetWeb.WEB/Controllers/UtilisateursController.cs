using System;
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
    public class UtilisateursController : Controller
    {
        //private Projet_GestionEntities db = new Projet_GestionEntities();
        private UtilisateurBL BLUser = new UtilisateurBL();
        // GET: Utilisateurs
        public ActionResult Index()
        {
            List<UtilisateurModel> utilisateur = new List<UtilisateurModel>();
            utilisateur = BLUser.GetLesUtilisateur();
            //db.Utilisateur.Include(u => u.Profil);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateur = BLUser.GetUnUtilisateurById(id.GetValueOrDefault());
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
           // ViewBag.profil_id = new SelectList(BLUser, "id", "nom");
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nom,prenom,mail,password,last_login,deconnexion,purge,profil_nom")] UtilisateurModel utilisateur)
        {
            if (ModelState.IsValid)
            {
                BLUser.CreateUtilisateur(utilisateur.nom,utilisateur.prenom,utilisateur.mail,utilisateur.password,utilisateur.last_login,utilisateur.deconnexion,utilisateur.purge, utilisateur.profil_nom);
                //db.Utilisateur.Add(utilisateur);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            /*ViewBag.profil_id = new SelectList(db.Profil, "id", "nom", utilisateur.profil_id);*/
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateur = BLUser.GetUnUtilisateurById(id.GetValueOrDefault());
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            //ViewBag.profil_id = new SelectList(db.Profil, "id", "nom", utilisateur.profil_id);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,profil_id,nom,prenom,mail,password,last_login,deconnexion,purge")] UtilisateurModel utilisateur)
        {
            if (ModelState.IsValid)
            {
                BLUser.ModifierUtilisateur(utilisateur.id, utilisateur.profil_id, utilisateur.nom, utilisateur.prenom, utilisateur.mail, utilisateur.password, utilisateur.last_login, utilisateur.deconnexion, utilisateur.purge);
                //db.Entry(utilisateur).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.profil_id = new SelectList(db.Profil, "id", "nom", utilisateur.profil_id);
            return View(utilisateur);
        }

        //GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLUser.DeleteUtilisateur(id.GetValueOrDefault());
            //Utilisateur utilisateur = db.Utilisateur.Find(id);
            if (BLUser == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLUser.DeleteUtilisateur(id);
            //Utilisateur utilisateur = db.Utilisateur.Find(id);
            //db.Utilisateur.Remove(utilisateur);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        UtilisateurBL.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
