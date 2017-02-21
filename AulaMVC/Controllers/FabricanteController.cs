using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AulaMVC.Models;

namespace AulaMVC.Controllers
{
    public class FabricanteController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Fabricante
        public async Task<ActionResult> Index()
        {
            return View(await db.Fabricantes.ToListAsync());
        }

        // GET: Fabricante/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricanteModel fabricanteModel = await db.Fabricantes.FindAsync(id);
            if (fabricanteModel == null)
            {
                return HttpNotFound();
            }
            return View(fabricanteModel);
        }

        // GET: Fabricante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabricante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] FabricanteModel fabricanteModel)
        {
            if (ModelState.IsValid)
            {
                db.Fabricantes.Add(fabricanteModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fabricanteModel);
        }

        // GET: Fabricante/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricanteModel fabricanteModel = await db.Fabricantes.FindAsync(id);
            if (fabricanteModel == null)
            {
                return HttpNotFound();
            }
            return View(fabricanteModel);
        }

        // POST: Fabricante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] FabricanteModel fabricanteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricanteModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fabricanteModel);
        }

        // GET: Fabricante/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricanteModel fabricanteModel = await db.Fabricantes.FindAsync(id);
            if (fabricanteModel == null)
            {
                return HttpNotFound();
            }
            return View(fabricanteModel);
        }

        // POST: Fabricante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FabricanteModel fabricanteModel = await db.Fabricantes.FindAsync(id);
            db.Fabricantes.Remove(fabricanteModel);
            await db.SaveChangesAsync();
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
