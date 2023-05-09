using API.Application;
using API.Application.FluentValidations.Categories;
using API.Application.FluentValidations.Products;
using API.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
