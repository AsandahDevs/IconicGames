global using Games.Models;
global using Games.Data;
using Games.Services.GameService;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Games API", Version = "v1" });
});
builder.Services.AddScoped<IGame, GameService>();

var connectionString = builder.Configuration.GetConnectionString("GamingDatabaseConnection") ??
     throw new InvalidOperationException("Connection string 'GamingDatabaseConnection'" +
    " not found.");

// Database configuration
builder.Services.AddDbContext<GamesContext>(options =>
    options.UseNpgsql(connectionString));

// Authentication configuration
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<GamesContext>();


var app = builder.Build();

// Apply migrations at startup
var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var context = services.GetRequiredService<GamesContext>();
context.Database.Migrate(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Games API v1"));
}

app.UseHttpsRedirection();

app.MapIdentityApi<IdentityUser>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
