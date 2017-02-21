using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AulaMVC.Models;

namespace AulaMVCApi.Controllers
{
    public class TipoController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Tipo
        public IQueryable<TipoModel> GetTipos()
        {
            return db.Tipos;
        }

        // GET: api/Tipo/5
        [ResponseType(typeof(TipoModel))]
        public IHttpActionResult GetTipoModel(int id)
        {
            TipoModel tipoModel = db.Tipos.Find(id);
            if (tipoModel == null)
            {
                return NotFound();
            }

            return Ok(tipoModel);
        }

        // PUT: api/Tipo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoModel(int id, TipoModel tipoModel)
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
                db.SaveChanges();
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
        public IHttpActionResult PostTipoModel(TipoModel tipoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipos.Add(tipoModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoModel.Id }, tipoModel);
        }

        // DELETE: api/Tipo/5
        [ResponseType(typeof(TipoModel))]
        public IHttpActionResult DeleteTipoModel(int id)
        {
            TipoModel tipoModel = db.Tipos.Find(id);
            if (tipoModel == null)
            {
                return NotFound();
            }

            db.Tipos.Remove(tipoModel);
            db.SaveChanges();

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