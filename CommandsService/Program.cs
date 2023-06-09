using CommandManagement.Infrastructure.Configuration;
using CommandManagement.Infrastructure.EFCore.Context;
using RabbitMQLManagement.Infrastructure.Services.Repository.AsyncDataServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//? IDK it should implement in here
builder.Services.AddHostedService<MessageBusSubscriber>();
CommandManagementBootstrapper.Configure(builder.Services);
//RabbitMQlBootstrapper.Configure(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
