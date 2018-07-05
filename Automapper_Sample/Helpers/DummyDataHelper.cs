using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automapper_Sample.Models.DBEntities;

namespace Automapper_Sample.Helpers
{
    public static class DummyDataHelper
    {
        private static List<CountryEntity> _dBCountries = null;
        private static List<PersonEntity> _dBPeople = null;

        public static List<CountryEntity> DBCountries
        {
            get
            {
                if (_dBCountries == null)
                {
                    _dBCountries = GenerateCountries();
                }

                return _dBCountries;
            }
            set { _dBCountries = value; }
        }

        public static List<PersonEntity> DBPeople
        {
            get
            {
                if (_dBPeople == null)
                {
                    _dBPeople = GeneratePeople();
                }

                return _dBPeople;
            }
            set { _dBPeople = value; }
        }


        private static List<PersonEntity> GeneratePeople()
        {
            List<PersonEntity> retval = new List<PersonEntity>();

            CountryEntity aus = DBCountries.Find(c => c.Country_Code == "AUS");

            PersonEntity person1 = new PersonEntity()
            {
                Person_Id = Guid.NewGuid(),
                Person_FirstName = "Bruce",
                Person_LastName = "Wayne",
                Person_Country = aus
            };

            CountryEntity nz = DBCountries.Find(c => c.Country_Code == "NZL");

            PersonEntity person2 = new PersonEntity()
            {
                Person_Id = Guid.NewGuid(),
                Person_FirstName = "Clark",
                Person_LastName = "Kent",
                Person_Country = nz
            };

            retval.Add(person1);
            retval.Add(person2);

            return retval;
        }

        private static List<CountryEntity> GenerateCountries()
        {
            List<CountryEntity> retval = new List<CountryEntity>();

            CountryEntity aus = new CountryEntity()
            {
                Country_Id = Guid.NewGuid(),
                Country_Code = "AUS",
                Country_Name = "Australia"
            };

            CountryEntity nz = new CountryEntity()
            {
                Country_Id = Guid.NewGuid(),
                Country_Code = "NZL",
                Country_Name = "New Zealand"
            };

            CountryEntity sng = new CountryEntity()
            {
                Country_Id = Guid.NewGuid(),
                Country_Code = "SNG",
                Country_Name = "Singapore"
            };

            retval.Add(aus);
            retval.Add(nz);
            retval.Add(sng);

            return retval;
        }

    }
}