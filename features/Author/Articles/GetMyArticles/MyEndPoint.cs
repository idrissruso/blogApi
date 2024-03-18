
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
                throw new Exception("kjkjhjkn");
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