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
    public class PersonRepo : IRepository<PersonVM>
    {
        public PersonVM Add(PersonVM item)
        {
            PersonVM retval = null;

            if (Get(item.Id) == null)
            {
                PersonEntity tempPerson = AutoMapperConfig.ConfigureMapper()
                    .Map<PersonVM, PersonEntity>(item);
                DummyDataHelper.DBPeople.Add(tempPerson);
            }

            retval = Get(item.Id);

            return retval;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PersonVM Get(Guid id)
        {
            PersonVM retval = null;
            PersonEntity tempPerson = DummyDataHelper.DBPeople.Find(p => p.Person_Id == id);

            if (tempPerson != null)
            {
                retval = AutoMapperConfig.ConfigureMapper().Map<PersonEntity, PersonVM>(tempPerson);
            }

            return retval;
        }

        public List<PersonVM> Get()
        {
            List<PersonVM> retval = null;

            retval = AutoMapperConfig.ConfigureMapper()
                .Map<List<PersonEntity>, List<PersonVM>>(DummyDataHelper.DBPeople);

            return retval;
        }

        public PersonVM Update(PersonVM item)
        {
            PersonVM retval = null;
            int index = DummyDataHelper.DBPeople.FindIndex(c => c.Person_Id == item.Id);

            if (index >= 0)
            {
                DummyDataHelper.DBPeople[index] = 
                    AutoMapperConfig.ConfigureMapper().Map<PersonVM, PersonEntity>(item);
            }

            retval = Get(item.Id);

            return retval;
        }
    }
}