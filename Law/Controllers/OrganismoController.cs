using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Law.Models;

namespace Law.Controllers
{
    public class OrganismoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Organismo
        public ActionResult Index()
        {
            var organismo = db.Organismo.Include(o => o.Estado).Include(o => o.TOrganismo);
            return View(organismo.ToList());
        }

        // GET: Organismo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organismo organismo = db.Organismo.Find(id);
            if (organismo == null)
            {
                return HttpNotFound();
            }
            return View(organismo);
        }

        // GET: Organismo/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado");
            ViewBag.TOrganismoId = new SelectList(db.TOrganismos, "TOrganismoId", "DscTOrganismo");
            return View();
        }

        // POST: Organismo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganismoId,DscOrganismo,Sigla,URL,TOrganismoId,UserId,Registro,Modificacion,Identificador,EstadoId")] Organismo organismo)
        {
            if (ModelState.IsValid)
            {
                db.Organismo.Add(organismo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", organismo.EstadoId);
            ViewBag.TOrganismoId = new SelectList(db.TOrganismos, "TOrganismoId", "DscTOrganismo", organismo.TOrganismoId);
            return View(organismo);
        }

        // GET: Organismo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organismo organismo = db.Organismo.Find(id);
            if (organismo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", organismo.EstadoId);
            ViewBag.TOrganismoId = new SelectList(db.TOrganismos, "TOrganismoId", "DscTOrganismo", organismo.TOrganismoId);
            return View(organismo);
        }

        // POST: Organismo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganismoId,DscOrganismo,Sigla,URL,TOrganismoId,UserId,Registro,Modificacion,Identificador,EstadoId")] Organismo organismo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organismo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", organismo.EstadoId);
            ViewBag.TOrganismoId = new SelectList(db.TOrganismos, "TOrganismoId", "DscTOrganismo", organismo.TOrganismoId);
            return View(organismo);
        }

        // GET: Organismo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organismo organismo = db.Organismo.Find(id);
            if (organismo == null)
            {
                return HttpNotFound();
            }
            return View(organismo);
        }

        // POST: Organismo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organismo organismo = db.Organismo.Find(id);
            db.Organismo.Remove(organismo);
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
