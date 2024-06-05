using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineOrders
{
    // Product class
    public class Product
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Calculate total cost of the product
        public decimal CalculateTotalCost()
        {
            return Price * Quantity;
        }
    }

    // Customer class
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        // Check if the customer is in the USA
        public bool IsInUSA()
        {
            return Address.IsInUSA();
        }
    }

    // Address class
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // Check if the address is in the USA
        public bool IsInUSA()
        {
            return Country == "USA";
        }

        // Get the full address as a string
        public string GetFullAddress()
        {
            return $"{Street}\n{City}, {State}\n{Country}";
        }
    }

    // Order class
    public class Order
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }

        // Calculate total cost of the order
        public decimal CalculateTotalOrderCost()
        {
            decimal totalCost = Products.Sum(p => p.CalculateTotalCost());

            // Shipping cost
            decimal shippingCost = Customer.IsInUSA() ? 5 : 35;

            return totalCost + shippingCost;
        }

        // Get packaging label
        public string GetPackagingLabel()
        {
            StringBuilder label = new StringBuilder();
            foreach (var product in Products)
            {
                label.AppendLine($"Product: {product.Name} (ID: {product.ProductId})");
            }
            return label.ToString();
        }

        // Get shipping label
        public string GetShippingLabel()
        {
            return $"Customer: {Customer.Name}\nAddress:\n{Customer.Address.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create products
            var product1 = new Product { Name = "T-Shirt", ProductId = 1, Price = 10, Quantity = 2 };
            var product2 = new Product { Name = "Shoes", ProductId = 2, Price = 50, Quantity = 1 };

            // Create customer
            var customer = new Customer
            {
                Name = "John Doe",
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Seattle",
                    State = "WA",
                    Country = "USA"
                }
            };

            // Create order
            var order = new Order
            {
                Customer = customer,
                Products = new List<Product> { product1, product2 }
            };

            // Display results
            Console.WriteLine("Packaging Label:");
            Console.WriteLine(order.GetPackagingLabel());

            Console.WriteLine("\nShipping Label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"\nTotal order cost: ${order.CalculateTotalOrderCost()}");

            Console.ReadLine();
        }
    }
}