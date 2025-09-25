using CrudApi.Extensions;
using CrudApi.Interfaces.Repositories;
using CrudApi.Interfaces.Services;
using CrudApi.Models.Mappings;
using CrudApi.Repositories;
using CrudApi.Services;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlDatabase(builder.Configuration);
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

FluentMapper.Initialize(configure =>
{
    configure.AddMap(new CustomerMap());
    configure.AddMap(new ProductMap());

    configure.ForDommel();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
