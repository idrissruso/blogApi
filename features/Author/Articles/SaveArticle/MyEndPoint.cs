using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using blogApi.data;
using FastEndpoints;
using AutoMapper;
using Config;

namespace blogApi.features.Author.Articles.SaveArticle
{
    public class MyEndPoint : Endpoint<NewArticleRequest, Response<NewArticleResponse>>
    {
        private readonly AppDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public MyEndPoint(AppDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override void Configure()
        {
            Post("article/new");
            AllowAnonymous();
        }

        public override async Task HandleAsync(NewArticleRequest req, CancellationToken token)
        {
            try
            {
                var newArticle = _mapper.Map<ArticleEntity>(req);
                _dbContext.Add(newArticle);
                _dbContext.SaveChanges();

                await SendAsync(new(
                    message: "Article created successfully",
                    statusCode: 201
                ), cancellation: token);

            }
            catch (System.Exception ex)
            {
                await SendAsync(new(
                    message: ex.Message,
                    statusCode: 400
                ), cancellation: token);
            }


        }
    }
}