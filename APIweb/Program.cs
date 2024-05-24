using APIweb.Data;
using APIweb.Infraestrutura;
using APIweb.Models;
using APIweb.Validations;
using FluentValidation;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<Produto>, ValidateProduct>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:3000/Tabela", "http://localhost:3000/home")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
