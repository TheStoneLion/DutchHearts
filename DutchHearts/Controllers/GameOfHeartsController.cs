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
    public class GameOfHeartsController : Controller
    {
        private DutchHeartsContext db = new DutchHeartsContext();

        // GET: GameOfHearts
        public ActionResult Index()
        {
            var gameOfHearts = db.GameOfHearts.Include(g => g.CurrentGamePhase);
            return View(gameOfHearts.ToList());
        }

        // GET: GameOfHearts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameOfHearts gameOfHearts = db.GameOfHearts.Find(id);
            if (gameOfHearts == null)
            {
                return HttpNotFound();
            }
            return View(gameOfHearts);
        }

        // GET: GameOfHearts/Create
        public ActionResult Create()
        {
            ViewBag.GamePhaseID = new SelectList(db.GamePhases, "GamePhaseID", "Phase");
            return View();
        }

        // POST: GameOfHearts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameOfHeartsID,PlayerID,RoundID,GameDate,GamePhaseID")] GameOfHearts gameOfHearts)
        {
            if (ModelState.IsValid)
            {
                db.GameOfHearts.Add(gameOfHearts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GamePhaseID = new SelectList(db.GamePhases, "GamePhaseID", "Phase", gameOfHearts.GamePhaseID);
            return View(gameOfHearts);
        }

        // GET: GameOfHearts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameOfHearts gameOfHearts = db.GameOfHearts.Find(id);
            if (gameOfHearts == null)
            {
                return HttpNotFound();
            }
            ViewBag.GamePhaseID = new SelectList(db.GamePhases, "GamePhaseID", "Phase", gameOfHearts.GamePhaseID);
            return View(gameOfHearts);
        }

        // POST: GameOfHearts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameOfHeartsID,PlayerID,RoundID,GameDate,GamePhaseID")] GameOfHearts gameOfHearts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameOfHearts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GamePhaseID = new SelectList(db.GamePhases, "GamePhaseID", "Phase", gameOfHearts.GamePhaseID);
            return View(gameOfHearts);
        }

        // GET: GameOfHearts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameOfHearts gameOfHearts = db.GameOfHearts.Find(id);
            if (gameOfHearts == null)
            {
                return HttpNotFound();
            }
            return View(gameOfHearts);
        }

        // POST: GameOfHearts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameOfHearts gameOfHearts = db.GameOfHearts.Find(id);
            db.GameOfHearts.Remove(gameOfHearts);
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
