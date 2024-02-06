using System;
using System.Collections.Generic;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class InventoryManager
{
    static List<Product> inventory = new List<Product>();
    static int productIdCounter = 1;

    static void Main()
    {
        Console.WriteLine("Welcome to Inventory Manager!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product Information");
            Console.WriteLine("3. View Inventory");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        ViewInventory();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Inventory Manager. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the product price: ");
        if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
        {
            Console.Write("Enter the product quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity >= 0)
            {
                Product newProduct = new Product
                {
                    Id = productIdCounter++,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };

                inventory.Add(newProduct);
                Console.WriteLine("Product added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid price. Please enter a non-negative number.");
        }
    }

    static void UpdateProduct()
    {
        Console.Write("Enter the product ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int productId))
        {
            Product productToUpdate = inventory.Find(p => p.Id == productId);

            if (productToUpdate != null)
            {
                Console.WriteLine($"Current Information for Product ID {productId}:");
                Console.WriteLine($"Name: {productToUpdate.Name}");
                Console.WriteLine($"Price: {productToUpdate.Price:C}");
                Console.WriteLine($"Quantity: {productToUpdate.Quantity}");

                Console.WriteLine("\nEnter new information:");

                Console.Write("Enter the new product name (press Enter to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    productToUpdate.Name = newName;
                }

                Console.Write("Enter the new product price (press Enter to keep current): ");
                string newPriceInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPriceInput) && double.TryParse(newPriceInput, out double newPrice) && newPrice >= 0)
                {
                    productToUpdate.Price = newPrice;
                }

                Console.Write("Enter the new product quantity (press Enter to keep current): ");
                string newQuantityInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newQuantityInput) && int.TryParse(newQuantityInput, out int newQuantity) && newQuantity >= 0)
                {
                    productToUpdate.Quantity = newQuantity;
                }

                Console.WriteLine("Product information updated successfully!");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid product ID.");
        }
    }

    static void ViewInventory()
    {
        Console.WriteLine("\nCurrent Inventory:");

        if (inventory.Count == 0)
        {
            Console.WriteLine("No products available in the inventory.");
        }
        else
        {
            foreach (var product in inventory)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}");
            }
        }
    }
}
