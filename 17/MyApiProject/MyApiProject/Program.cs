using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApiProject.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Adds controller services to the application, enabling the use of MVC pattern.

// Add a singleton service to provide the data
builder.Services.AddSingleton<IDataService, DataService>(); // Registers the IDataService with a singleton lifetime, meaning one instance will be used throughout the application lifecycle.

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); // Adds endpoint API explorer to discover the endpoints in the application.
builder.Services.AddSwaggerGen(); // Adds Swagger generation services for creating the API documentation.

var app = builder.Build(); // Builds the application

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Enables developer exception page for detailed error information in development environment.
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger(); // Enables middleware to serve the generated Swagger as a JSON endpoint.
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // Specifies the Swagger JSON endpoint.
        c.RoutePrefix = string.Empty;  // To serve the Swagger UI at the app's root.
    });
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.

app.UseAuthorization(); // Adds authorization middleware to the request pipeline.

app.MapControllers(); // Maps the controller endpoints to the request pipeline.

app.Run(); // Runs the application

// Interface defining the data service
public interface IDataService
{
    IEnumerable<Item> GetItems(); // Method to get a collection of Item objects.
}

// Implementation of the data service
public class DataService : IDataService
{
    private readonly List<Item> _items; // List to store the items.

    public DataService()
    {
        // Read the data.json file
        var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", "data.json")); // Reads the data.json file from the Data directory.
        _items = JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>(); // Deserializes the JSON content into a list of Item objects.
    }

    public IEnumerable<Item> GetItems()
    {
        return _items; // Returns the list of items.
    }
}
