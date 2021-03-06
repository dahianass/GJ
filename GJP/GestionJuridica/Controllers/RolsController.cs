﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GestionJuridica.Models;

namespace GestionJuridica.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GestionJuridica.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Rol>("Rols");
    builder.EntitySet<Permisos>("Permisos"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RolsController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Rols
        [EnableQuery]
        public IQueryable<Rol> GetRols()
        {
            return db.Rol;
        }

        // GET: odata/Rols(5)
        [EnableQuery]
        public SingleResult<Rol> GetRol([FromODataUri] int key)
        {
            return SingleResult.Create(db.Rol.Where(rol => rol.IdRol == key));
        }

        // PUT: odata/Rols(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Rol> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rol rol = db.Rol.Find(key);
            if (rol == null)
            {
                return NotFound();
            }

            patch.Put(rol);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(rol);
        }

        // POST: odata/Rols
        public IHttpActionResult Post(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rol.Add(rol);
            db.SaveChanges();

            return Created(rol);
        }

        // PATCH: odata/Rols(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Rol> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rol rol = db.Rol.Find(key);
            if (rol == null)
            {
                return NotFound();
            }

            patch.Patch(rol);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(rol);
        }

        // DELETE: odata/Rols(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Rol rol = db.Rol.Find(key);
            if (rol == null)
            {
                return NotFound();
            }

            db.Rol.Remove(rol);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Rols(5)/Permisos
        [EnableQuery]
        public IQueryable<Permisos> GetPermisos([FromODataUri] int key)
        {
            return db.Rol.Where(m => m.IdRol == key).SelectMany(m => m.Permisos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolExists(int key)
        {
            return db.Rol.Count(e => e.IdRol == key) > 0;
        }
    }
}
