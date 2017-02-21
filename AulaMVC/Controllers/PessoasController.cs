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
    public class PessoasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pessoas
        public async Task<ActionResult> Index()
        {
            return View(await db.Pessoas.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoasMesaModel pessoasMesaModel = await db.Pessoas.FindAsync(id);
            if (pessoasMesaModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoasMesaModel);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Calote")] PessoasMesaModel pessoasMesaModel)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoasMesaModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pessoasMesaModel);
        }

        // GET: Pessoas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoasMesaModel pessoasMesaModel = await db.Pessoas.FindAsync(id);
            if (pessoasMesaModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoasMesaModel);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Calote")] PessoasMesaModel pessoasMesaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoasMesaModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pessoasMesaModel);
        }

        // GET: Pessoas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoasMesaModel pessoasMesaModel = await db.Pessoas.FindAsync(id);
            if (pessoasMesaModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoasMesaModel);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PessoasMesaModel pessoasMesaModel = await db.Pessoas.FindAsync(id);
            db.Pessoas.Remove(pessoasMesaModel);
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
