
//1. Domain Services 
//	Thsese services encapsulate domain specific logic and operations 
//	these services encapsulate the business rules and workflows and domain specific operations

using static System.Net.Mime.MediaTypeNames;

public class ProductService
{
	private readonly IProductRepositry _productRepositry;

	public ProductService(IProductRepositry productRepositry)
	{
		_productRepositry = productRepositry;
	}

	public void AddProduct(Product product)
	{
		//validate product data
		//perform business logic 
		_productRepositry.Add(product);
	}
}

//2.application services: application services provide high-level functionality
//and orchestrate interactions between the presentation layer and the domain model.
//they often correspond to use cases or user stories in the application
//and encapsulate the logic required to fulfill those use cases.
//application services may coordinate multiple domain services and handle transaction management,
//security, and error handling.
public class OrderService
{
	private readonly IOrderRepository _orderRepository;

	public OrderService(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public void PlaceOrder(Order order)
	{
		// Perform order validation
		// Calculate order total
		// Update inventory
		// Handle payment processing
		_orderRepository.Add(order);
	}

	// Other methods for managing orders
}

//3.Integration Services: Integration services facilitate communication with external systems,
//services, or APIs. They encapsulate the logic required to interact with external resources,
//handle data exchange formats, and manage communication protocols.
//Integration services abstract away the details of integration,
//making it easier to maintain and evolve the application's interactions with external systems.

public class ExternalApiService
{
	public ExternalApiSource CallApi(ExternalApiRequest request)
	{
		//make HTTP request to external API
		//handle response parsing and error handling 
		//return response data
	}
}

//4. Utility Services: 
//provide resuable functionality that doesn't fit neatly into domain or application-specific categories.
//they may include services for logging, caching, encryption, authentication, or other cross-cutting concerns.
//utility services common funcionality that is used across different parts of the applications.

public class LogginService
{
	public void LogMessage(string message)
	{
		//log message to file or external logging service 
	}
}

//overall, the services section in the BLL serves as the backbone of the business logic layer, 
//encapsulating the core functionality and operations of the application. 
//by organizing service into cohesive units of functionality, developers can maintain a modular 
//maintainable and testable code, facilitating the implementation and evolution of the business logic layer
