using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AulaMVC.Models;

namespace AulaMVC.Controllers.Api
{
    public class TipoController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Tipo
        [Route]
        public IQueryable<TipoModel> GetTipos()
        {
            return db.Tipos;
        }

        // GET: api/Tipo/5
        [ResponseType(typeof(TipoModel))]
        public async Task<IHttpActionResult> GetTipoModel(int id)
        {
            TipoModel tipoModel = await db.Tipos.FindAsync(id);
            if (tipoModel == null)
            {
                return NotFound();
            }

            return Ok(tipoModel);
        }

        // PUT: api/Tipo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoModel(int id, TipoModel tipoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoModel.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tipo
        [ResponseType(typeof(TipoModel))]
        public async Task<IHttpActionResult> PostTipoModel(TipoModel tipoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipos.Add(tipoModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoModel.Id }, tipoModel);
        }

        // DELETE: api/Tipo/5
        [ResponseType(typeof(TipoModel))]
        public async Task<IHttpActionResult> DeleteTipoModel(int id)
        {
            TipoModel tipoModel = await db.Tipos.FindAsync(id);
            if (tipoModel == null)
            {
                return NotFound();
            }

            db.Tipos.Remove(tipoModel);
            await db.SaveChangesAsync();

            return Ok(tipoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoModelExists(int id)
        {
            return db.Tipos.Count(e => e.Id == id) > 0;
        }
    }
}