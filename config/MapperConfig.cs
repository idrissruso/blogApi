using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Author.Signup;
using AutoMapper;
using blogApi.data;
using blogApi.features.Author.Articles.GetArticle;
using blogApi.features.Author.Articles.SaveArticle;

namespace blogApi.config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<NewAuthorRequest, AuthorEntity>().ReverseMap();
            CreateMap<NewArticleRequest, ArticleEntity>().ReverseMap();
            CreateMap<ArticleEntity, NewArticleResponse>().ReverseMap();
            CreateMap<ArticleEntity, GetArticleByIdResponse>().ReverseMap();
        }

    }
}