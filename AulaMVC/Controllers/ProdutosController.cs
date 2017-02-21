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
    public class ProdutosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Produtos
        public async Task<ActionResult> Index()
        {
            var produtos = db.Produtos.Include(p => p.FabricanteModel).Include(p => p.TipoModel);
            return View(await produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = await db.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.FabricanteModelId = new SelectList(db.Fabricantes, "Id", "Nome");
            ViewBag.TipoModelId = new SelectList(db.Tipos, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Volume,Valor,TeorAlc,TipoModelId,FabricanteModelId")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtoModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteModelId = new SelectList(db.Fabricantes, "Id", "Nome", produtoModel.FabricanteModelId);
            ViewBag.TipoModelId = new SelectList(db.Tipos, "Id", "Nome", produtoModel.TipoModelId);
            return View(produtoModel);
        }

        // GET: Produtos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = await db.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteModelId = new SelectList(db.Fabricantes, "Id", "Nome", produtoModel.FabricanteModelId);
            ViewBag.TipoModelId = new SelectList(db.Tipos, "Id", "Nome", produtoModel.TipoModelId);
            return View(produtoModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Volume,Valor,TeorAlc,TipoModelId,FabricanteModelId")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteModelId = new SelectList(db.Fabricantes, "Id", "Nome", produtoModel.FabricanteModelId);
            ViewBag.TipoModelId = new SelectList(db.Tipos, "Id", "Nome", produtoModel.TipoModelId);
            return View(produtoModel);
        }

        // GET: Produtos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = await db.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProdutoModel produtoModel = await db.Produtos.FindAsync(id);
            db.Produtos.Remove(produtoModel);
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
