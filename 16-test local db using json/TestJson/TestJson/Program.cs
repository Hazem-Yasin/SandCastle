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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
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
