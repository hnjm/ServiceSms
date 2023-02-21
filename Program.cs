using ServiceSms.Controllers;
using ServiceSms.Database;
using ServiceSms.Model;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(@"Data Source=(localdb)\localdbdemo;Integrated Security=True"));
builder.Services.AddScoped<ISmsServiceFactory, SmsServiceFactory>();
builder.Services.AddScoped<ISmsRepository, SmsVendorGR>();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
