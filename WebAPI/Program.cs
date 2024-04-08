using Business.Abstract;
using Business.Concrete;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//altaki builder.Services.AddSingleton<IProductDal,EfProductDal>(); bunun yaptýðýný
// Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject --> bunlar bize AOP imaný saðlar
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductManager>();// bana arka planda bir referasn oluþtur birisi senden IProductService
//isterse ona  arka planda bir tane ProductManager oluþtur ve ver 
builder.Services.AddSingleton<IProductDal,EfProductDal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
