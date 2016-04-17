using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DutchHearts.Models;

namespace DutchHearts.Controllers
{
    public class GamePhasesController : Controller
    {
        private DutchHeartsContext db = new DutchHeartsContext();

        // GET: GamePhases
        public ActionResult Index()
        {
            return View(db.GamePhases.ToList());
        }

        // GET: GamePhases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePhase gamePhase = db.GamePhases.Find(id);
            if (gamePhase == null)
            {
                return HttpNotFound();
            }
            return View(gamePhase);
        }

        // GET: GamePhases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamePhases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GamePhaseID,Phase")] GamePhase gamePhase)
        {
            if (ModelState.IsValid)
            {
                db.GamePhases.Add(gamePhase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gamePhase);
        }

        // GET: GamePhases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePhase gamePhase = db.GamePhases.Find(id);
            if (gamePhase == null)
            {
                return HttpNotFound();
            }
            return View(gamePhase);
        }

        // POST: GamePhases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GamePhaseID,Phase")] GamePhase gamePhase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamePhase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gamePhase);
        }

        // GET: GamePhases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePhase gamePhase = db.GamePhases.Find(id);
            if (gamePhase == null)
            {
                return HttpNotFound();
            }
            return View(gamePhase);
        }

        // POST: GamePhases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamePhase gamePhase = db.GamePhases.Find(id);
            db.GamePhases.Remove(gamePhase);
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
