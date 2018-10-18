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
    public class TOrganismoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TOrganismo
        public ActionResult Index()
        {
            var tOrganismos = db.TOrganismos.Include(t => t.Estado);
            return View(tOrganismos.ToList());
        }

        // GET: TOrganismo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOrganismo tOrganismo = db.TOrganismos.Find(id);
            if (tOrganismo == null)
            {
                return HttpNotFound();
            }
            return View(tOrganismo);
        }

        // GET: TOrganismo/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado");
            return View();
        }

        // POST: TOrganismo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TOrganismoId,DscTOrganismo,UserId,Registro,Modificacion,Identificador,EstadoId")] TOrganismo tOrganismo)
        {
            if (ModelState.IsValid)
            {
                db.TOrganismos.Add(tOrganismo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", tOrganismo.EstadoId);
            return View(tOrganismo);
        }

        // GET: TOrganismo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOrganismo tOrganismo = db.TOrganismos.Find(id);
            if (tOrganismo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", tOrganismo.EstadoId);
            return View(tOrganismo);
        }

        // POST: TOrganismo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TOrganismoId,DscTOrganismo,UserId,Registro,Modificacion,Identificador,EstadoId")] TOrganismo tOrganismo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOrganismo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", tOrganismo.EstadoId);
            return View(tOrganismo);
        }

        // GET: TOrganismo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOrganismo tOrganismo = db.TOrganismos.Find(id);
            if (tOrganismo == null)
            {
                return HttpNotFound();
            }
            return View(tOrganismo);
        }

        // POST: TOrganismo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOrganismo tOrganismo = db.TOrganismos.Find(id);
            db.TOrganismos.Remove(tOrganismo);
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
