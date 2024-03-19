using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Author.Signup;
using AutoMapper;
using blogApi.data;
using blogApi.features.Author.Articles.GetArticle;
using blogApi.features.Author.Articles.GetMyArticles;
using blogApi.features.Author.Articles.SaveArticle;
using blogApi.features.Public.GetArticleList;

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
            CreateMap<ArticleEntity, GetAllArticlesResponse>().ReverseMap();
            CreateMap<ArticleEntity, ArticleByAuthorResponse>().ReverseMap();
        }

    }
}