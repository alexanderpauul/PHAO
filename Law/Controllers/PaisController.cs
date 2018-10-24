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
    public class PaisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pais
        public ActionResult Index()
        {
            return View(db.Paises.ToList());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaisId,ISO,DscPais,Registro,Modificacion,Identificador")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaisId,ISO,DscPais,Registro,Modificacion,Identificador")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = db.Paises.Find(id);
            db.Paises.Remove(pais);
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
