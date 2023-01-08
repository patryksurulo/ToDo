using System.Data;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;
using ServiceStack.OrmLite.MySql;
using ToDo.Models;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;

var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
builder.Services.AddControllers();


var dbFactory = new OrmLiteConnectionFactory(conf.GetConnectionString(
    "TodoDatabase"), new MySql55DialectProvider());
var db = dbFactory.OpenDbConnection();
db.CreateTableIfNotExists<Todo>();

builder.Services.AddSingleton<IDbConnection>(db);
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();