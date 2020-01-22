using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.App_Start
{
    public class MappingProfile : Profile
    {
        /* create mapping convention
         mapper from customer to Dto and Dto to Customer*/
         public MappingProfile()
        {
            //Customers
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer >().ForMember(c => c.Id, opt => opt.Ignore()); 
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //Movies
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore()); 
            Mapper.CreateMap<GenreType, GenreTypeDto>();
            Mapper.CreateMap<GenreTypeDto, GenreType>();

          

        }
    }

  
}