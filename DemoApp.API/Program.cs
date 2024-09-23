using DemoApp.Model.Services;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Utils.UserSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Monee.Logic.DbLayer;

var builder = WebApplication.CreateBuilder(args);

//Bind user secrets to a object
UserSecretsRoot userSecret = new();
builder.Configuration.Bind(userSecret);

builder.Services.AddScoped<ILogger>(t =>LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger("DemoApp"));

if (userSecret == null
    || userSecret.ConnectionStrings == null
    || String.IsNullOrEmpty(userSecret.ConnectionStrings.DemoAppDbConnectionString))
    throw new ArgumentNullException(nameof(userSecret));

builder.Services.AddScoped<IAccountService, AccountService>();

//Database context configuration
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(userSecret.ConnectionStrings.DemoAppDbConnectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
            c.CustomOperationIds(
                    e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}"));

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
