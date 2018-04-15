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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            Person person = new Person()
            {
                ID = 0,
                FirstName = "Test",
                LastName = "People",
                PayRate = 2.54,
                StartDate = DateTime.Now,
            };
            //string str = "Search " + id.ToString() + " is found!";
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
        public void Delete(int id)
        {
        }
    }
}
