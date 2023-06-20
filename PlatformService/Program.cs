using Microsoft.Extensions.Hosting.Internal;
using PlatformManagement.Infrastructure.Configuration;
using PlatformManagement.Infrastructure.EFCore.Context;
using PlatformManagement.Infrastructure.Services.SyncDataServices.Grpc;
using PlatformManagement.Infrastructure.Services.SyncDataServices.http;
using RabbitMQLManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
IHostEnvironment env = new HostingEnvironment();

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PlatformsConn");

PlatformManagementBootstrapper.Configure(builder.Services, env , connectionString);
RabbitMQlBootstrapper.Configure(builder.Services);
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
//? Grpc Config
builder.Services.AddGrpc();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//? To Know the Command Endpoint because of development and production stage

Console.WriteLine($"--> CommandService Endpoint {builder.Configuration.GetSection("CommandService").Value} <--");

var app = builder.Build();


PrepDB.PrepPopulation(app , env.IsProduction());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//? Grpc Config
app.MapGrpcService<GrpcPlatformService>();

app.MapGet("../PlatformManagement.Infrastructure.Services/Protos/Platforms.proto", async context =>
{
    await context.Response.WriteAsync(
        File.ReadAllText("../PlatformManagement.Infrastructure.Services/Protos/Platforms.proto"));
});

app.Run();

