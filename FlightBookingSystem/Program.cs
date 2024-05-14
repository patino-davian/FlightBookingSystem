using FlightBookingSystem.Data;
using FlightBookingSystem.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen( c =>
{
    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
    {
        Description = "Development Server",
        Url = "https://localhost:7216"
    });

    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"] + e.ActionDescriptor.RouteValues["controller"]}");
});

builder.Services.AddSingleton<Entities>();

var app = builder.Build();

var entities = app.Services.CreateScope().ServiceProvider.GetService<Entities>();

var random = new Random();

Flight[] flightsToSeed = new Flight[]
{
    new (
                Guid.NewGuid(),
                "American Airlines",
                random.Next(90, 600).ToString(),
                new TimePlace("Los Angeles", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("San Antonio", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),
            new (
                Guid.NewGuid(),
                "Delta Airlines",
                random.Next(90, 700).ToString(),
                new TimePlace("Chicago", DateTime.Now.AddHours(random.Next(1,10))),
                new TimePlace("Dallas", DateTime.Now.AddHours(random.Next(4,24))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "United Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("New York", DateTime.Now.AddHours(random.Next(1,12))),
                new TimePlace("Miami", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),
            new (
                Guid.NewGuid(),
                "Southwest Airlines",
                random.Next(90, 700).ToString(),
                new TimePlace("Houston", DateTime.Now.AddHours(random.Next(1,12))),
                new TimePlace("Denver", DateTime.Now.AddHours(random.Next(12,24))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "JetBlue Airways",
                random.Next(90, 500).ToString(),
                new TimePlace("Orlando", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Seattle", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Alaska Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("Portland", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Las Vegas", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Spirit Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("Atlanta", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Boston", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Frontier Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("Phoenix", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Detroit", DateTime.Now.AddHours(random.Next(12,24))),
                random.Next(1, 100))
};
entities.Flights.AddRange(flightsToSeed);


app.UseCors(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

app.UseSwagger().UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
