using CustomerAPIProj.Repositories;
using CustomerAPIProj.Services.IServices;
using CustomerAPIProj.Services;
using FluentValidation.AspNetCore;
using CustomerAPIProj.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomer, CustomerService>();
builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<AddCustomerValidator>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
