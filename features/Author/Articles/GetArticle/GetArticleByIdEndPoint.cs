using System;
using System.Linq;
using System.Threading.Tasks;
using blogApi.data;
using Config;
using FastEndpoints;

namespace blogApi.features.Author.Articles.GetArticle
{
    public class GetArticleByIdEndPoint : Endpoint<GetArticleByIdRequest, Response<GetArticleByIdResponse>>
    {
        private readonly AppDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public GetArticleByIdEndPoint(AppDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("article/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetArticleByIdRequest req, CancellationToken token)
        {
            try
            {
                var article = _dbContext.Articles.FirstOrDefault(a => a.Id == req.Id);

                if (article == null)
                {
                    await SendAsync(new Response<GetArticleByIdResponse>(
                        message: "Article not found",
                        statusCode: 404
                    ), cancellation: token);
                    return;
                }

                await SendAsync(new(
                        data: _mapper.Map<GetArticleByIdResponse>(article),
                        statusCode: 200
                    )
                        , cancellation: token);

            }
            catch (System.Exception ex)
            {
                await SendAsync(new Response<GetArticleByIdResponse>(
                    message: ex.Message,
                    statusCode: 400
                ), cancellation: token);
            }
        }
    }
}