using System.Reflection;
using API.Injections;
using FilterSharp.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFilterSharp(op => op.DefaultPageSize = 15);

builder.Services.AddDbContext<LibraSysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("Connection").Value));

builder.Services.AddScopedServices();

var app = builder.Build();

app.Run();