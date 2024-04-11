using Microsoft.AspNetCore.Identity;
using N.Layer.Sample.Api.Endpoints;
using N.Layer.Sample.Api.Middlewares;
using N.Layer.Sample.Core;
using N.Layer.Sample.Data;
using N.Layer.Sample.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreDependencies(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<NLayerDbContext>()
    .AddApiEndpoints();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ApiExceptionMiddleware>();

app.UseAuthorization();

app.MapIdentityApi<User>();

RouteGroupBuilder apiRoute = app.MapGroup("api");

apiRoute.MapRecipeEndpoints();

app.Run();