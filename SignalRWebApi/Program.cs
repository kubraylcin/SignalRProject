using FluentValidation;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.BusinessLayer.Container;
using SignalR.BusinessLayer.ValidationRules.ReservationRules;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRWebApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt =>
{
    //cors=? 
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()//gelen herhangi bir ba�l��a izin ver
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();

    });
});
builder.Services.AddSignalR();


// Add services to the container.
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());// AutoMapper servislerini ekler ve ge�erli derlemeyi tarayarak e�leme profillerini y�kler.

builder.Services.ContainerDependencies();

builder.Services.AddValidatorsFromAssemblyContaining<CreateReservationValidation>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 

builder.Services.AddControllers();
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
app.UseCors("CorsPolicy"); //keyi �a��rd�k yukarda tan�mlanan
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub"); //bu enpoint localhost://1234/signalrhub istekte bulunaca��m�z yeri g�steriyorz

app.Run();
//istekte buludnu�umuz 
//localhost://1234/swagger/catgeory/�ndex
//localhost://1234/signalrhub istekte bulundu�umuz