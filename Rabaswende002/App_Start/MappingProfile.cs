using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Rabaswende002.Dtos;
using Rabaswende002.Models;

namespace Rabaswende002.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto 
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto , Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();



            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            // Dto to domain 
            Mapper.CreateMap<CustomerDto, Customer>()
               .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());



            //for rental movie and ther customer
     //       Mapper.CreateMap<Movie, RentalMovieDto>();
       //     Mapper.CreateMap<Customer, NewRentalDto>();
        }

        protected override void Configure()
        {
         
        }
    }
}