namespace MyApiProject.Models
{
    // Define a model class to represent an item in the application
    public class Item
    {
        // Property to hold the unique identifier for the item
        // 'Id' is an integer that serves as the primary key for the item
        public int Id { get; set; }

        // Property to hold the name of the item
        // 'Name' is a string representing the name of the item
        public string Name { get; set; }

        // Property to hold the value of the item
        // 'Value' is a string representing the value associated with the item
        public string Value { get; set; }
    }
}
