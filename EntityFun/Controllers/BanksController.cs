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
using EntityFun.Models;

namespace EntityFun.Controllers
{
    public class BanksController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Banks
        public IQueryable<Bank> GetBanks()
        {
            return db.Banks;
        }

        // GET: api/Banks/5
        [ResponseType(typeof(Bank))]
        public IHttpActionResult GetBank(int id)
        {
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

        // PUT: api/Banks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBank(int id, Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank.Id)
            {
                return BadRequest();
            }

            db.Entry(bank).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
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

        // POST: api/Banks
        [ResponseType(typeof(Bank))]
        public IHttpActionResult PostBank(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Banks.Add(bank);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bank.Id }, bank);
        }

        // DELETE: api/Banks/5
        [ResponseType(typeof(Bank))]
        public IHttpActionResult DeleteBank(int id)
        {
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return NotFound();
            }

            db.Banks.Remove(bank);
            db.SaveChanges();

            return Ok(bank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankExists(int id)
        {
            return db.Banks.Count(e => e.Id == id) > 0;
        }
    }
}