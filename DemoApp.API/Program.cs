using DemoApp.Model.Utils.UserSettings;
using Microsoft.EntityFrameworkCore;
using Monee.Logic.DbLayer;

var builder = WebApplication.CreateBuilder(args);

//Bind user secrets to a object
UserSecretsRoot userSecret = new();
builder.Configuration.Bind(userSecret);

if (userSecret == null
    || userSecret.ConnectionStrings == null
    || String.IsNullOrEmpty(userSecret.ConnectionStrings.DemoAppDbConnectionString))
    throw new ArgumentNullException(nameof(userSecret));

//Database context configuration
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(userSecret.ConnectionStrings.DemoAppDbConnectionString));


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services
    .AddAuthorization();
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
