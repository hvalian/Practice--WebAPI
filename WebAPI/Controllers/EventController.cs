using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EventController : ApiController
    {
        private MVCAPPEntities db = new MVCAPPEntities();

        // GET api/Event
        public IEnumerable<EventTB> GetEventTBs()
        {
            return db.EventTBs.AsEnumerable();
        }

        // GET api/Event/5
        public EventTB GetEventTB(int id)
        {
            EventTB eventtb = db.EventTBs.Find(id);
            if (eventtb == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return eventtb;
        }

        // PUT api/Event/5
        public HttpResponseMessage PutEventTB(int id, EventTB eventtb)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != eventtb.EventId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(eventtb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Event
        public HttpResponseMessage PostEventTB(EventTB eventtb)
        {
            if (ModelState.IsValid)
            {
                db.EventTBs.Add(eventtb);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, eventtb);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = eventtb.EventId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Event/5
        public HttpResponseMessage DeleteEventTB(int id)
        {
            EventTB eventtb = db.EventTBs.Find(id);
            if (eventtb == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.EventTBs.Remove(eventtb);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, eventtb);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}