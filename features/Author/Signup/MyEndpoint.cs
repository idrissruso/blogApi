using Admin.Login;
using blogApi.data;
using Config;
using FastEndpoints;


namespace Author.Signup
{
    public class NewAuthor(AppDbContext? dbContext, AutoMapper.IMapper mapper) : Endpoint<NewAuthorRequest, Response<NewAuthResponse>>
    {
        protected readonly AppDbContext? _dbContext = dbContext;
        protected readonly AutoMapper.IMapper _mapper = mapper;

        public override void Configure()
        {
            Post("/author/signup");

            AllowAnonymous();
        }

        public override async Task HandleAsync(NewAuthorRequest req, CancellationToken ct)
        {

            try
            {
                var newAuthor = _mapper.Map<AuthorEntity>(req);
                _dbContext?.Add(newAuthor);
                _dbContext?.SaveChanges();

                await SendAsync(new(
                        message: "Author created successfully",
                        statusCode: 201
                ), cancellation: ct);
            }
            catch (System.Exception ex)
            {
                // return a bad request 
                await SendAsync(new(
                    message: ex.Message,
                    statusCode: 400), cancellation: ct
                );
            }

        }
    }
}