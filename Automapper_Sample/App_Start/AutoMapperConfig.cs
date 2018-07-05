using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automapper_Sample.Models.DBEntities;
using Automapper_Sample.Models.ViewModels;
using AutoMapper;

namespace Automapper_Sample.App_Start
{
    //TODO: refactor code to allow for easier access to the mapper object and so that the mappings are always re-initialized when invoked
    public class AutoMapperConfig
    {
        public static IMapper ConfigureMapper()
        {

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CountryVM, CountryEntity>()
                    .ForMember(dest => dest.Country_Id, opts => opts.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Country_Code, opts => opts.MapFrom(src => src.Code))
                    .ForMember(dest => dest.Country_Name, opts => opts.MapFrom(src => src.Name));

                cfg.CreateMap<CountryEntity, CountryVM>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Country_Id))
                    .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.Country_Code))
                    .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Country_Name));

                cfg.CreateMap<PersonVM, PersonEntity>()
                    .ForMember(dest => dest.Person_Id, opts => opts.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Person_FirstName, opts => opts.MapFrom(src => src.GivenName))
                    .ForMember(dest => dest.Person_LastName, opts => opts.MapFrom(src => src.SurName))
                    .ForMember(dest => dest.Person_Country, opts => opts.MapFrom(src => src.Country));

                cfg.CreateMap<PersonEntity, PersonVM>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Person_Id))
                    .ForMember(dest => dest.GivenName, opts => opts.MapFrom(src => src.Person_FirstName))
                    .ForMember(dest => dest.SurName, opts => opts.MapFrom(src => src.Person_LastName))
                    .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Person_Country));



            });

            return config.CreateMapper();
        }
    }
}