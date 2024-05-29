using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApiProject.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add a singleton service to provide the data
builder.Services.AddSingleton<IDataService, DataService>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;  // To serve the Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public interface IDataService
{
    IEnumerable<Item> GetItems();
}

public class DataService : IDataService
{
    private readonly List<Item> _items;

    public DataService()
    {
        // Read the data.json file
        var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", "data.json"));
        _items = JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>();
    }

    public IEnumerable<Item> GetItems()
    {
        return _items;
    }
}
