using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using blogApi.data;
using Config;
using FastEndpoints;

namespace blogApi.features.Public.GetArticleList
{
    public class GelAllArticlesEndPoint : EndpointWithoutRequest<Response<List<GetAllArticlesResponse>>>
    {


        private readonly AppDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public GelAllArticlesEndPoint(AppDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override void Configure()
        {
            Get("article/list");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var articles = _dbContext.Articles.ToList();
                List<GetAllArticlesResponse> mappedArticles = articles.Select(x => _mapper.Map<GetAllArticlesResponse>(x)).ToList();
                await SendAsync(new(
                    mappedArticles,
                    (int)HttpStatusCode.OK
                ), cancellation: ct);
            }
            catch (System.Exception ex)
            {

                await SendAsync(new(
                    ex.Message,
                    (int)HttpStatusCode.InternalServerError
                ), cancellation: ct);
            }

        }


    }
}