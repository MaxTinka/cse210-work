using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create an address for the customer
        Address address = new Address("123 Main St", "Anytown", "CA", "USA");

        // Create a customer
        Customer customer = new Customer("John Doe", address);

        // Create some products
        Product product1 = new Product(1, "Laptop", 999.99m, 1);
        Product product2 = new Product(2, "Mouse", 25.50m, 2);
        Product product3 = new Product(3, "Keyboard", 45.00m, 1);

        // Create an order
        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);
        order.AddProduct(product3);

        // Display order details
        Console.WriteLine(order.GeneratePackingLabel());
        Console.WriteLine(order.GenerateShippingLabel());
        Console.WriteLine($"Total Price: {order.CalculateTotalPrice():C}");
    }
}

public class Product
{
    // Properties
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    // Constructor
    public Product(int id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Method to get the total price for this product
    public decimal GetTotalPrice()
    {
        return Price * Quantity; // Calculate total cost based on price and quantity
    }
}

public class Address
{
    // Properties
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Method to return a formatted string of the address
    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

public class Customer
{
    // Properties
    public string Name { get; private set; }
    public Address Address { get; private set; }

    // Constructor
    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Method to check if the customer lives in the USA
    public bool LivesInUSA()
    {
        return Address.IsInUSA(); // Call the method from the Address class
    }
}

public class Order
{
    // Properties
    private List<Product> products;
    public Customer Customer { get; private set; }

    // Constructor
    public Order(Customer customer)
    {
        Customer = customer;
        products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total price of the order
    public decimal CalculateTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice(); // Get total price for each product
        }
        // Add shipping cost based on the customer's address
        total += Customer.LivesInUSA() ? 5.00m : 35.00m; // Shipping cost
        return total;
    }

    // Method to generate a packing label
    public string GeneratePackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"Product ID: {product.Id}, Name: {product.Name}, Quantity: {product.Quantity}\n";
        }
        return label;
    }

    // Method to generate a shipping label
    public string GenerateShippingLabel()
    {
        return $"Shipping Label:\nTo: {Customer.Name}\n{Customer.Address.GetFullAddress()}\n";
    }
}