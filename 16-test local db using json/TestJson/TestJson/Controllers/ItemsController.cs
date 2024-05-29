using Microsoft.AspNetCore.Mvc;
using MyApiProject.Models;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IDataService _dataService;

    public ItemsController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public IEnumerable<Item> Get()
    {
        return _dataService.GetItems();
    }
}
