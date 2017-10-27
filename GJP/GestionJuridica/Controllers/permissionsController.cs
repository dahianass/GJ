﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GestionJuridica.Models;

namespace GestionJuridica.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GestionJuridica.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<permission>("permissions");
    builder.EntitySet<resource>("resource"); 
    builder.EntitySet<role>("role"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class permissionsController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/permissions
        [EnableQuery]
        public IQueryable<permission> Getpermissions()
        {
            return db.permission;
        }

        // GET: odata/permissions(5)
        [EnableQuery]
        public SingleResult<permission> Getpermission([FromODataUri] long key)
        {
            return SingleResult.Create(db.permission.Where(permission => permission.id_permission == key));
        }

        // PUT: odata/permissions(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<permission> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            permission permission = await db.permission.FindAsync(key);
            if (permission == null)
            {
                return NotFound();
            }

            patch.Put(permission);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!permissionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(permission);
        }

        // POST: odata/permissions
        public async Task<IHttpActionResult> Post(permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.permission.Add(permission);
            await db.SaveChangesAsync();

            return Created(permission);
        }

        // PATCH: odata/permissions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<permission> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            permission permission = await db.permission.FindAsync(key);
            if (permission == null)
            {
                return NotFound();
            }

            patch.Patch(permission);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!permissionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(permission);
        }

        // DELETE: odata/permissions(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            permission permission = await db.permission.FindAsync(key);
            if (permission == null)
            {
                return NotFound();
            }

            db.permission.Remove(permission);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/permissions(5)/resource
        [EnableQuery]
        public SingleResult<resource> Getresource([FromODataUri] long key)
        {
            return SingleResult.Create(db.permission.Where(m => m.id_permission == key).Select(m => m.resource));
        }

        // GET: odata/permissions(5)/role
        [EnableQuery]
        public SingleResult<role> Getrole([FromODataUri] long key)
        {
            return SingleResult.Create(db.permission.Where(m => m.id_permission == key).Select(m => m.role));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool permissionExists(long key)
        {
            return db.permission.Count(e => e.id_permission == key) > 0;
        }
    }
}
