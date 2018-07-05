using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using Automapper_Sample.App_Start;
using Automapper_Sample.Helpers;
using Automapper_Sample.Models.DBEntities;
using Automapper_Sample.Models.ViewModels;
using Automapper_Sample.Repository.Abstract;

namespace Automapper_Sample.Repository.Concrete
{
    //Using the DummyDataHelper class to simulate a DB of some sort
    public class CountryRepo : IRepository<CountryVM>
    {
        public CountryVM Add(CountryVM item)
        {
            CountryVM retval = null;

            if (DummyDataHelper.DBCountries.Find(c => c.Country_Id == item.Id) == null)
            {
                CountryEntity tempCountry = AutoMapperConfig.ConfigureMapper().Map<CountryVM, CountryEntity>(item);
                DummyDataHelper.DBCountries.Add(tempCountry);
            }

            retval = Get(item.Id);

            return retval;
        }

        public bool Delete(Guid id)
        {
            bool retval = false;
            int index = DummyDataHelper.DBCountries.FindIndex(c => c.Country_Id == id);

            if (index >= 0)
            {
                DummyDataHelper.DBCountries.RemoveAt(index);
                retval = true;
            }

            return true;
        }

        public CountryVM Get(Guid id)
        {
            CountryVM retval = null;
            CountryEntity tempCountry = DummyDataHelper.DBCountries.Find(c => c.Country_Id == id);

            if (tempCountry != null)
            {
                retval = AutoMapperConfig.ConfigureMapper().Map<CountryEntity, CountryVM>(tempCountry);
            }

            return retval;
        }

        public List<CountryVM> Get()
        {
            List<CountryVM> retval = null;

            retval = AutoMapperConfig.ConfigureMapper()
                .Map<List<CountryEntity>, List<CountryVM>>(DummyDataHelper.DBCountries);

            return retval;
        }

        public CountryVM Update(CountryVM item)
        {
            CountryVM retval = null;

            int index = DummyDataHelper.DBCountries.FindIndex(c => c.Country_Id == item.Id);

            if (index >= 0)
            {
                DummyDataHelper.DBCountries[index] =
                    AutoMapperConfig.ConfigureMapper().Map<CountryVM, CountryEntity>(item);
            }

            retval = Get(item.Id);

            return retval;
        }
    }
}