using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using Automapper_Sample.App_Start;
using Automapper_Sample.Factory.Abstract;
using Automapper_Sample.Helpers;
using Automapper_Sample.Models.DBEntities;
using Automapper_Sample.Models.ViewModels;
using Automapper_Sample.Repository.Abstract;
using Automapper_Sample.Repository.Concrete;

namespace Automapper_Sample.Factory.Concrete
{
    public class PersonFactory: IFactory<PersonVM>
    {
        private readonly IRepository<PersonVM> _personRepository = null;
        private readonly IRepository<CountryVM> _countryRepository = null;

        public PersonFactory()
        {
            _personRepository = new PersonRepo();
            _countryRepository = new CountryRepo();
        }

        //Overload constructor to allow for Unit Tests i.e. supply a dmmy repo similar to what I have done in this project
        public PersonFactory(IRepository<PersonVM> personRepository, IRepository<CountryVM> countryRepository)
        {
            _personRepository = personRepository;
            _countryRepository = countryRepository;
        }

        public PersonVM AddItem(PersonVM person)
        {
            PersonVM retval = null;
            retval = _personRepository.Add(person);

            return retval;
        }

        public PersonVM GetItem(Guid id)
        {
            PersonVM retval = null;
            retval = _personRepository.Get(id); //Get person
            retval.Countries = _countryRepository.Get(); //Attach list of countries to be used in the dropdown list when int he edit screem

            return retval;
        }

        public List<PersonVM> GetItems()
        {
            List<PersonVM> retval = null;

            retval = _personRepository.Get();

            return retval;
        }



        public PersonVM UpdateItem(PersonVM item)
        {
            PersonVM retval = null;

            //Since the country object is malformed due to the Form Post configuration assign the country object
            item.Country = _countryRepository.Get(item.Country.Id); // Assign fully populated country object
            retval = _personRepository.Update(item);

            //If we didn't utilize the factory / repo pattern we would end up with code as below. This has a code smell 
            //stinking of functional smear between handling business logic and data access logic (amongst other things).

            /*
            item.Country = AutoMapperConfig.ConfigureMapper().Map<CountryEntity, CountryVM>(DummyDataHelper.DBCountries.Find(c => c.Country_Id == item.Country.Id)); ;
            DummyDataHelper.DBPeople[DummyDataHelper.DBPeople.FindIndex(p => p.Person_Id == item.Id)] = 
                AutoMapperConfig.ConfigureMapper().Map<PersonVM, PersonEntity>(item);
            retval = GetItem(item.Id);
            */
            return retval;
        }

    }
}