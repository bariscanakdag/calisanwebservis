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
using barisCrudService.Models;

namespace barisCrudService.Controllers
{
    public class CalisanController : ApiController
    {
        private  MyDatabaseEntities1 db = new MyDatabaseEntities1();
        

        // GET: api/Calisan
        public IQueryable<Calisan> GetCalisan()
        {
            return db.Calisan;
        }

        // GET: api/Calisan/5
        [ResponseType(typeof(Calisan))]
        public IHttpActionResult GetCalisan(int id)
        {
            Calisan calisan = db.Calisan.Find(id); 
            if (calisan == null)
            {
                return NotFound();
            }

            return Ok(calisan);
        }

        // PUT: api/Calisan/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalisan(int id, Calisan calisan)
        {
    

           

            db.Entry(calisan).State = EntityState.Modified;
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalisanExists(id))
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

        // POST: api/Calisan
        [ResponseType(typeof(Calisan))]
        public IHttpActionResult PostCalisan(Calisan calisan)
        {
 

            db.Calisan.Add(calisan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calisan.CalisanID }, calisan);
        }

        // DELETE: api/Calisan/5
        [ResponseType(typeof(Calisan))]
        public IHttpActionResult DeleteCalisan(int id)
        {
            Calisan calisan = db.Calisan.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            db.Calisan.Remove(calisan);
            db.SaveChanges();

            return Ok(calisan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalisanExists(int id)
        {
            return db.Calisan.Count(e => e.CalisanID == id) > 0;
        }
    }
}