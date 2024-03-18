using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;


namespace Public.GetArticlesList
{
    public class GetArticles : EndpointWithoutRequest<Response>
    {
        public override void Configure()
        {
            Get("article/list");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(new Response { Message = "Hello World" });
        }

    }
}