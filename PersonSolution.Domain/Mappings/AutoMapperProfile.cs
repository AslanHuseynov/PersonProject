using AutoMapper;
using PersonSolution.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSolution.Domain.Mappings
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();
        }
    }
}
