using blogApi.config;
using blogApi.data;
using FastEndpoints;
using FastEndpoints.Swagger;


var builder = WebApplication.CreateBuilder();
builder.Services
   .AddFastEndpoints()
   .SwaggerDocument();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();
