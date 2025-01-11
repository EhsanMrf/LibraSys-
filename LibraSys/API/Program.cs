using API.EndPoint;
using Application.Contract.IService;
using Application;
using Domian.Model.Book;
using FilterSharp.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LibraSysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("Connection").Value));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddFilterSharp(op => op.DefaultPageSize = 15);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapBookEndPoints();


app.Run();