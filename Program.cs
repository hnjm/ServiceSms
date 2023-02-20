using ServiceSms.Database;
using ServiceSms.Model;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection("MyConnectionString"));
builder.Services.AddTransient<IRepository<Sms>, Repository<Sms>>();

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
