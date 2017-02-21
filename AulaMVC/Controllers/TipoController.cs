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
    public class TipoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Tipo
        public async Task<ActionResult> Index()
        {
            return View(await db.Tipos.ToListAsync());
        }

        // GET: Tipo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoModel tipoModel = await db.Tipos.FindAsync(id);
            if (tipoModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoModel);
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoModel tipoModel)
        {
            if (ModelState.IsValid)
            {
                db.Tipos.Add(tipoModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoModel);
        }

        // GET: Tipo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoModel tipoModel = await db.Tipos.FindAsync(id);
            if (tipoModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoModel);
        }

        // POST: Tipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoModel tipoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoModel);
        }

        // GET: Tipo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoModel tipoModel = await db.Tipos.FindAsync(id);
            if (tipoModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoModel);
        }

        // POST: Tipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoModel tipoModel = await db.Tipos.FindAsync(id);
            db.Tipos.Remove(tipoModel);
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
