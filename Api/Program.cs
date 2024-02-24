using Api.Endpoints;
using Application.Queries;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Database;
using Infrastructure.Queries;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IGetArticleByIdQueryHandler, GetArticleByIdQueryHandler>();

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapArticleEndpoints();
app.UseHttpsRedirection();

app.Run();