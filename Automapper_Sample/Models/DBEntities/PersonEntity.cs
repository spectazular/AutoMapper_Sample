using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automapper_Sample.Models.DBEntities
{
    public class PersonEntity
    {
        public Guid Person_Id { get; set; }
        public string Person_FirstName { get; set; }
        public string Person_LastName { get; set; }
        public CountryEntity Person_Country { get; set; }
    }
}