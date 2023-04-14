using SndAPI.Data;
using SndAPI.Clients;
using SndAPI.Services;
using Microsoft.Win32.TaskScheduler;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IArshaService, ArshaService>();
builder.Services.AddScoped<IBdoApiClient, BdoApiClient>();
builder.Services.AddHostedService<RepeatingService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SndDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("SNDConnectionString")));
builder.Services.AddHttpClient();
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
