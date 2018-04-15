using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstRESTServer.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PayRate { get; set; }
        public DateTime StartDate { get; set; }
    }
}