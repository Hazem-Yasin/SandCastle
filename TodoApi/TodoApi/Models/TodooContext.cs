using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    // This class represents the database context for the Todo application.
    // It manages the connection to the database and the TodoItems table.
    public class TodoContext : DbContext
    {
        // The constructor accepts DbContextOptions of type TodoContext, which are passed to the base DbContext class.
        // This allows configuration options to be specified when creating an instance of TodoContext.
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        // This property represents the TodoItems table in the database.
        // The DbSet<TodoItem> type allows CRUD (Create, Read, Update, Delete) operations on TodoItems.
        // The null-forgiving operator (!) is used to indicate that this property will not be null,
        // ensuring the DbSet is always initialized properly by Entity Framework.
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}