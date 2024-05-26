//it interacts with the underlying data storage systems, like the databases, files or external services, 
//to perform CRUD operations and retreive data for the application,
//the DAL abstracts away the details of the data storage and reterival, 
//providing a consistent interface for the business logic layer to interact with, 

//here's what you might find in the data access layer: 
//1. Repositires: 
//it provides an abstration over data, so you don't need to worry about how the project interacts 
//with the database 
//it's like if you have categories for weapons in elden ring and you need to organize them 
//so you need to add a repository to each category that includes the actions you will need to take
//in the future for example if you need to know each weapon's strength and damage effect
using System;
using System.Collections;
using System.Security.AccessControl;
string Proudct = "test";
public interface IProductRepository
{
	Product GetById(int id);
	IEnumerable<Product> GetAll();
	void Add(Product product);
	void Update(Product product);
	void Delete(int id);
}
//2. Data Access Object (DAO)
//so it's used to encapsulate the logic required to interact with a specific data source, 
//like a databse or a table or a web service, they often contain methods for executing database queries,
//calling stored procedures, or making HTTP requests for external APIs
//EXAMPLE:
public class ProductDao
{
	public Product GetBYId(int id)
	{
		//Execute sql query to fetch product by ID
	}
	//other methods for CRUD operations
}
//3.Object Relational Mapping(ORM) Framework:
//ORM automates the process of storing and retreiving and managing data in a database, 
//it simplifes the development process by allowing developers to work with objects in their code, 
//while the ORM framewok handles the translation between those objects 
//EXAMPLE: 
public class MyDbContext : DbContext
{
	public DbSet<Product> Products { get; set; }
	//other DbSet Properties for other entites

	protected override void OnConfiguring(DbContextOptionsbuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("connectionString");
	}
}


//4. Unit Of Work
//so unit of work is like a sandbox for the changes we want to make to the database,
//so for example if we want to build a level in a game, this level will have multiple objects
//like streets and lamps and stuff like that, now we can run the project immeditly 
//but we can also create a unit of work before runing it and create a folder or a section for every object, 
//after that you can test ever object alone and then when you are sure that everything work you can 
//add it all together and run it
public interface IUnitOfWork : IDisposable
{
	void SaveChanges();
	void RollBack();
	//other methods for managin transactions
}


//5. Connection Managment: 
//DAL may include classes or components responsible for managing database connections and resoruces, 
//these classes ensure efficent connection pooling, handle connection timeouts and retries, 
//and manage connections such as database connections and transactions

//the data access layer provides a bridge between the application's business logic layer 
//and the underlying storage systems.
//By encapsulating data access logic in a seperate layer, we can acheive seperation of concerns 
//making it easier to evolve and scale the application over time.

public class DbConnectionFactory
{
	public IDbConnection CreateConnection()
	{
		//create and return a new databse connection
	}
}
