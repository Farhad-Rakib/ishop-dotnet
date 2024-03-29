using Command.API.Configurations;
using CommonSideCar.Helpers;
using CommonSideCar.Versions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddConfigurations();
builder.Host.UseSerilog(builder.Configuration);
// Add services to the container.
builder.Services.AddApiVersioningExtension();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
