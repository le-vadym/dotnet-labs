using Lab3.Models;
using Lab3.Pages;
using Lab3.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton(s =>
{
    var mongoClient = s.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase(builder.Configuration.GetSection("LibraryDatabase")["Name"]);
});
builder.Services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Redirect("/Index");
});

app.MapRazorPages();

app.UseStaticFiles();

app.Run();
