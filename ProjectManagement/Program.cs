using Contracts;
using LoggerService;
using NLog;
using ProjectManagement.Extensions;


var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

//controller tasýndý
builder.Services.AddControllers().AddApplicationPart(typeof(ProjectManagement.Presentation.AssemblyReference).Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
var logger1 = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger1);
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

var logger = app.Services.GetRequiredService<ILoggerManager>();


if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();