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
using GestionJuridica.Utilities;
using System.Runtime.Serialization.Json;

namespace GestionJuridica.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GestionJuridica.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<user>("users");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class usersController : ODataController
    {
        Encrypt objEncrypet = new Encrypt();
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/users
        [EnableQuery]
        public IQueryable<user> Getusers()
        {
            return db.user;
        }

        // GET: odata/users(5)
        [EnableQuery]
        public SingleResult<user> Getuser([FromODataUri] long key)
        {
            return SingleResult.Create(db.user.Where(user => user.id_user == key));
        }

        // PUT: odata/users(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<user> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user user = await db.user.FindAsync(key);
            if (user == null)
            {
                return NotFound();
            }

            if (patch.GetEntity().Password.Contains("[*IGGA*]"))
            {
                patch.GetEntity().Password = Encrypt.EncryptD(patch.GetEntity().Password.Replace("[*IGGA*]", ""));
            }
            
            patch.Put(user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // POST: odata/users
        public async Task<IHttpActionResult> Post(user user)
        {
            Rpta objRespta = new Rpta();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            user.Password = Encrypt.EncryptD(user.Password);
            var userB = db.user.Where(us => us.email == user.email).FirstOrDefault();
            
            if (userB == null)
            {
                db.user.Add(user);
                await db.SaveChangesAsync();
            }
            else {
                user.id_user = 0;
                user.name = "Usuario ya existe";
            }
            return Created(user);
        }

        // PATCH: odata/users(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<user> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user user = await db.user.FindAsync(key);
            if (user == null)
            {
                return NotFound();
            }

            patch.Patch(user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // DELETE: odata/users(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            user user = await db.user.FindAsync(key);
            if (user == null)
            {
                return NotFound();
            }

            db.user.Remove(user);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(long key)
        {
            return db.user.Count(e => e.id_user == key) > 0;
        }
    }
}
