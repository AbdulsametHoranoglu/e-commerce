using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Entities.Security.Encryption;
using Core.Entities.Security.JWT;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//burda diyoruz ki senin .net core alt yapýnda biliyorum IoC yapýsý var ama onu kullanma fabrika olarak autofac ki kullan
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.

//altaki builder.Services.AddSingleton<IProductDal,EfProductDal>(); bunun yaptýðýný
// Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject --> bunlar bize AOP imaný saðlar
builder.Services.AddControllers();
 var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters=new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
//autoFact yazdýðýmýz için bunlara artýk gerek yok

//builder.Services.AddSingleton<IProductService, ProductManager>();// bana arka planda bir referasn oluþtur birisi senden IProductService
////isterse ona  arka planda bir tane ProductManager oluþtur ve ver 
//builder.Services.AddSingleton<IProductDal,EfProductDal>();



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
