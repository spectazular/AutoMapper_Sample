using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automapper_Sample.Models.DBEntities
{
    public class CountryEntity
    {
        public Guid Country_Id { get; set; }
        public string Country_Code { get; set; }
        public string Country_Name { get; set; }
    }
}