
using Cositas.DataAccess;
using Cositas.Factories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



const string CONNECTIONNAME = "DBConnection";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton<TodoFactoryProvider>();
// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
