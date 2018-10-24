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
    public class TProyectoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TProyecto
        public ActionResult Index()
        {
            var tProyectos = db.TProyectos.Include(t => t.Estado);
            return View(tProyectos.ToList());
        }

        // GET: TProyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TProyecto tProyecto = db.TProyectos.Find(id);
            if (tProyecto == null)
            {
                return HttpNotFound();
            }
            return View(tProyecto);
        }

        // GET: TProyecto/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado");
            return View();
        }

        // POST: TProyecto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TNormaId,DscTNorma,UserId,Registro,Modificacion,Identificador,EstadoId")] TProyecto tProyecto)
        {
            if (ModelState.IsValid)
            {
                db.TProyectos.Add(tProyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", tProyecto.EstadoId);
            return View(tProyecto);
        }

        // GET: TProyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TProyecto tProyecto = db.TProyectos.Find(id);
            if (tProyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", tProyecto.EstadoId);
            return View(tProyecto);
        }

        // POST: TProyecto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TNormaId,DscTNorma,UserId,Registro,Modificacion,Identificador,EstadoId")] TProyecto tProyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tProyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "DscEstado", tProyecto.EstadoId);
            return View(tProyecto);
        }

        // GET: TProyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TProyecto tProyecto = db.TProyectos.Find(id);
            if (tProyecto == null)
            {
                return HttpNotFound();
            }
            return View(tProyecto);
        }

        // POST: TProyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TProyecto tProyecto = db.TProyectos.Find(id);
            db.TProyectos.Remove(tProyecto);
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
