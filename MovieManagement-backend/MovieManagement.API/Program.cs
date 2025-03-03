using Microsoft.EntityFrameworkCore;
using MovieManagement.DataDBContext;
using MovieManagement.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
  //  .AddCheck<DatabaseHealthCheck>("Database");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<TheaterService>();
builder.Services.AddScoped<SeatService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MovieDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("GlobalDB")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/_health");

app.UseAuthorization();

app.MapControllers();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.Run();
