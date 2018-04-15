using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstRESTServer.Models;

namespace FirstRESTServer.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            PersonPersistence pp = new PersonPersistence();
            return pp.getPerson().AsEnumerable();
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            PersonPersistence pp = new PersonPersistence();
            Person person = pp.getPerson(id);
            return person;
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersonPersistence pp = new PersonPersistence();
            value.ID = pp.addPerson(value);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);  //影片中示範的
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("person/{0}",value.ID));
            return response;
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]Person value)
        {
        }

        // DELETE: api/Person/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            PersonPersistence pp = new PersonPersistence();
            bool existed = pp.delPerson(id);

            if (existed)
            {
                response.StatusCode = HttpStatusCode.NoContent;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            return response;
        }
    }
}
