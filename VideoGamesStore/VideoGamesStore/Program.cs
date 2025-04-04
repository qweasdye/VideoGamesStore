using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System;
using VideoGames.Application.Services;
using VideoGameStore.DataAccess;
using VideoGameStore.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VideoGamesStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddScoped<IVideoGamesService, VideoGamesService>();
builder.Services.AddScoped<IVideoGamesRepository, VideoGamesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
