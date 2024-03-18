using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogApi.data;
using FastEndpoints;

namespace Author.Signup
{
    public class NewAuthor(AppDbContext? dbContext) : Endpoint<Request, Response>
    {
        protected readonly AppDbContext? _dbContext = dbContext;

        public override void Configure()
        {
            Post("/author/signup");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(new Response()
            {
                Message = $"Welcome {req.FirstName} {req.LastName}"
            });
        }
    }
}