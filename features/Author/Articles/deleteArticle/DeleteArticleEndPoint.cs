using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogApi.data;
using Config;
using FastEndpoints;

namespace blogApi.features.Author.Articles.deleteArticle
{
    public class DeleteArticleEndPoint : Endpoint<DeleteArticleRequest, Response<DeleteArticleResponse>>
    {

        private readonly AppDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public DeleteArticleEndPoint(AppDbContext appDb, AutoMapper.IMapper mapper)
        {
            _dbContext = appDb;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Delete("article/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteArticleRequest req, CancellationToken token)
        {
            try
            {
                var article = _dbContext.Articles.OrderBy(x => x.Id).LastOrDefault(x => x.Id == req.Id);

                if (article == null)
                {
                    await SendAsync(new Response<DeleteArticleResponse>(
                        message: "Article not found",
                        statusCode: 404
                    ), cancellation: token);
                    return;
                }

                _dbContext.Articles.Remove(article);
                _dbContext.SaveChanges();
                await SendAsync(new Response<DeleteArticleResponse>(
                    message: "Article deleted successfully",
                    statusCode: 200
                ), cancellation: token);

            }
            catch (System.Exception ex)
            {

                await SendAsync(new(ex.Message, 500), cancellation: token);
            }
        }
    }
}