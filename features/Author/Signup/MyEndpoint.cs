using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogApi.data;
using FastEndpoints;
using AutoMapper;

namespace Author.Signup
{
    public class NewAuthor(AppDbContext? dbContext, AutoMapper.IMapper mapper) : Endpoint<NewAuthorRequest, Response>
    {
        protected readonly AppDbContext _dbContext = dbContext;
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
                _dbContext.Add(newAuthor);
                _dbContext.SaveChanges();

                await SendAsync(new Response()
                {
                    Message = $"Welcome {req.FirstName} {req.LastName}"
                });

            }
            catch (System.Exception)
            {
                // return a bad request 
                await SendAsync(new Response()
                {
                    Message = "An error accured"
                });

            }

        }
    }
}