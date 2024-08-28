using Microsoft.EntityFrameworkCore;
using WebAPI_Student.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentsApiContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));
//another Way
//var provider = builder.Services.BuildServiceProvider();
//var config=provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<StudentsApiContext>(item => item.UseSqlServer(config.GetConnectionString("Dbconnection");

//Add logs in file
var _logger = new LoggerConfiguration()
    .WriteTo.File("D:\\LearnCore\\Logs\\log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.AddSerilog(_logger);

//
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
