using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automapper_Sample.Models.ViewModels
{
    public class PersonVM
    {
        [Key]
        public Guid Id { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }

        [Display(Name = "Country of Birth")]
        public CountryVM Country { get; set; }
        public IEnumerable<CountryVM> Countries { get; set; }
    }
}