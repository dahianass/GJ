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
    builder.EntitySet<role_by_action>("role_by_action");
    builder.EntitySet<action>("action"); 
    builder.EntitySet<role>("role"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class role_by_actionController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/role_by_action
        [EnableQuery]
        public IQueryable<role_by_action> Getrole_by_action()
        {
            return db.role_by_action;
        }

        // GET: odata/role_by_action(5)
        [EnableQuery]
        public SingleResult<role_by_action> Getrole_by_action([FromODataUri] long key)
        {
            return SingleResult.Create(db.role_by_action.Where(role_by_action => role_by_action.id_role_by_action == key));
        }

        // PUT: odata/role_by_action(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<role_by_action> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            role_by_action role_by_action = await db.role_by_action.FindAsync(key);
            if (role_by_action == null)
            {
                return NotFound();
            }

            patch.Put(role_by_action);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!role_by_actionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(role_by_action);
        }

        // POST: odata/role_by_action
        public async Task<IHttpActionResult> Post(role_by_action role_by_action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.role_by_action.Add(role_by_action);
            await db.SaveChangesAsync();

            return Created(role_by_action);
        }

        // PATCH: odata/role_by_action(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<role_by_action> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            role_by_action role_by_action = await db.role_by_action.FindAsync(key);
            if (role_by_action == null)
            {
                return NotFound();
            }

            patch.Patch(role_by_action);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!role_by_actionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(role_by_action);
        }

        // DELETE: odata/role_by_action(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            role_by_action role_by_action = await db.role_by_action.FindAsync(key);
            if (role_by_action == null)
            {
                return NotFound();
            }

            db.role_by_action.Remove(role_by_action);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/role_by_action(5)/action
        [EnableQuery]
        public SingleResult<action> Getaction([FromODataUri] long key)
        {
            return SingleResult.Create(db.role_by_action.Where(m => m.id_role_by_action == key).Select(m => m.action));
        }

        // GET: odata/role_by_action(5)/role
        [EnableQuery]
        public SingleResult<role> Getrole([FromODataUri] long key)
        {
            return SingleResult.Create(db.role_by_action.Where(m => m.id_role_by_action == key).Select(m => m.role));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool role_by_actionExists(long key)
        {
            return db.role_by_action.Count(e => e.id_role_by_action == key) > 0;
        }
    }
}
