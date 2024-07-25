using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Ziplink.API.DI;
using Ziplink.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Initialise addservice
var addSerivices = new AddSerivices();
addSerivices.Initialize(builder.Services);
//DbContext
builder.Services.AddDbContext<ZiplinkDbContext>(opts => opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Initialize log4net
var log4NetConfigFilePath = app.Configuration["Log4NetConfigFileName"];
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo((log4NetConfigFilePath == null ? "" : log4NetConfigFilePath)));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAllOrigins"); // Enable CORS using the specified policy

app.MapControllers();

app.Run();
