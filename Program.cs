using Microsoft.EntityFrameworkCore;
using TestApi.DataBase;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = AppContext.BaseDirectory
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews(); // For MVC controllers and views

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Configure OpenAPI/Swagger services
builder.Services.AddEndpointsApiExplorer();  // For endpoint discovery
builder.Services.AddSwaggerGen();  // For generating Swagger documentation

// Configure Kestrel to listen on HTTP and HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    // Configure Kestrel server
    options.Listen(System.Net.IPAddress.Any, 7262, listenOptions =>
            {
                //listenOptions.UseHttps();  // HTTPS port from appsettings.json
                listenOptions.UseHttps("/Users/shruti/dev-cert.pfx","password");
            });
    options.Listen(System.Net.IPAddress.Any, 5041);  // HTTP
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();  // Enable Swagger middleware
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestApi");
        c.RoutePrefix = string.Empty;  // Redirect root to Swagger UI
    });  // Enable Swagger UI for interactive API documentation

app.MapGet("/", () => Results.Redirect("/swagger"));
// Add middleware
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
