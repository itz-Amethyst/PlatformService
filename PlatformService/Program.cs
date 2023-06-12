using PlatformManagement.Infrastructure.Configuration;
using PlatformManagement.Infrastructure.EFCore.Context;
using PlatformService.SyncDataServices.http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("");

PlatformManagementBootstrapper.Configure(builder.Services);
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

