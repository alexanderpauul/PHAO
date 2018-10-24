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
    public class TEstadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TEstado
        public ActionResult Index()
        {
            return View(db.TEstados.ToList());
        }

        // GET: TEstado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEstado tEstado = db.TEstados.Find(id);
            if (tEstado == null)
            {
                return HttpNotFound();
            }
            return View(tEstado);
        }

        // GET: TEstado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEstado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEstadoId,DscTEstado,Habilitado,UserId,Registro,Modificacion,Identificador")] TEstado tEstado)
        {
            if (ModelState.IsValid)
            {
                db.TEstados.Add(tEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEstado);
        }

        // GET: TEstado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEstado tEstado = db.TEstados.Find(id);
            if (tEstado == null)
            {
                return HttpNotFound();
            }
            return View(tEstado);
        }

        // POST: TEstado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEstadoId,DscTEstado,Habilitado,UserId,Registro,Modificacion,Identificador")] TEstado tEstado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEstado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEstado);
        }

        // GET: TEstado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEstado tEstado = db.TEstados.Find(id);
            if (tEstado == null)
            {
                return HttpNotFound();
            }
            return View(tEstado);
        }

        // POST: TEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEstado tEstado = db.TEstados.Find(id);
            db.TEstados.Remove(tEstado);
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
