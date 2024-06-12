using Microsoft.AspNetCore.Mvc; // Import the necessary namespace for ASP.NET Core MVC functionality
using MyApiProject.Models; // Import the namespace where your data models are defined
using System.Collections.Generic; // Import the namespace for using collections such as IEnumerable

// Define this class as an API controller, which will handle HTTP requests and responses
[ApiController]
// Define the route template for this controller. "api/[controller]" means the route will be "api/Items" if the controller name is "ItemsController"
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    // Declare a private readonly field for the data service dependency
    private readonly IDataService _dataService;

    // Constructor to initialize the ItemsController with a dependency injection of IDataService
    public ItemsController(IDataService dataService)
    {
        // Assign the injected IDataService instance to the private field
        _dataService = dataService;
    }

    // Define a GET endpoint to retrieve a list of items
    // This endpoint will respond to GET requests at "api/Items"
    [HttpGet]
    public IEnumerable<Item> Get()
    {
        // Call the GetItems method of the data service to retrieve the list of items
        // and return it as the response of this endpoint
        return _dataService.GetItems();
    }
}
