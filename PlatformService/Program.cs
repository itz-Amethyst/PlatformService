using Microsoft.Extensions.Hosting.Internal;
using PlatformManagement.Infrastructure.Configuration;
using PlatformManagement.Infrastructure.EFCore.Context;
using PlatformService.SyncDataServices.http;

var builder = WebApplication.CreateBuilder(args);
IHostEnvironment env = new HostingEnvironment();

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PlatformsConn");

PlatformManagementBootstrapper.Configure(builder.Services, env , connectionString);
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//? To Know the Command Endpoint because of development and production stage

Console.WriteLine($"--> CommandService Endpoint {builder.Configuration.GetSection("CommandService").Value} <--");

var app = builder.Build();


PrepDB.PrepPopulation(app);


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

