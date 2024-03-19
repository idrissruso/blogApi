
using System.Net;
using blogApi.data;
using Config;
using FastEndpoints;


namespace blogApi.features.Author.Articles.GetMyArticles
{
    public class MyEndPoint : Endpoint<ArticleByAuthorRequest, Response<List<ArticleByAuthorResponse>>>
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
            Get("article/{AuthorId}/list");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ArticleByAuthorRequest request, CancellationToken token)
        {
            try
            {
                var articles = _dbContext.Articles.Where(x => x.Id == request.AuthorId).ToList();
                List<ArticleByAuthorResponse> mappedArticles = articles.Select(x => _mapper.Map<ArticleByAuthorResponse>(x)).ToList();

                if (mappedArticles.Count == 0)
                {
                    await SendAsync(new(
                        message: "No articles found for this author.",
                        statusCode: (int)HttpStatusCode.NotFound
                    ), cancellation: token);
                    return;
                }


                await SendAsync(new(
                    data: mappedArticles,
                    statusCode: (int)HttpStatusCode.OK
                ), cancellation: token);
            }
            catch (System.Exception ex)
            {

                await SendAsync(new(
                    message: ex.Message,
                    statusCode: 500

                ), cancellation: token);
            }
        }
    }
}