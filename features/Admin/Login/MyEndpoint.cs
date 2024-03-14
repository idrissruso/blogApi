using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;

namespace Admin.Login
{
    public class MyEndpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/admin/login");
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