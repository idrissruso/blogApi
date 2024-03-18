using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Author.Signup;
using AutoMapper;
using blogApi.data;

namespace blogApi.config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<NewAuthorRequest, AuthorEntity>().ReverseMap();
        }

    }
}