// Define the Smartphone class
public class Smartphone
{
    // Private member variables
    private string brand;
    private string model;
    private decimal price;
    private string specs;

    // Constructor to initialize a smartphone object
    public Smartphone(string brand, string model, decimal price, string specs)
    {
        this.brand = brand;
        this.model = model;
        this.price = price;
        this.specs = specs;
    }

    // Public method to display smartphone details
    public void DisplayInfo()
    {
        Console.WriteLine($"Smartphone Details:\nBrand: {brand}\nModel: {model}\nPrice: R{price}\nSpecifications: {specs}");
    }
}

// Main program to simulate a cellphone store
public class Program
{
    public static void Main(string[] args)
    {
        // Define available brands, models, prices, and specs
        Dictionary<string, List<(string Model, decimal Price, string Specs)>> cellphoneInventory = new Dictionary<string, List<(string, decimal, string)>>
        {
            { "Samsung", new List<(string, decimal, string)> {
                ("Galaxy S21", 14499.99m, "128GB Storage, 8GB RAM, 4000mAh Battery"),
                ("Galaxy A52", 6299.99m, "128GB Storage, 6GB RAM, 4500mAh Battery"),
                ("Galaxy Z Fold 3", 32499.99m, "256GB Storage, 12GB RAM, 4400mAh Battery"),
                ("Galaxy Note 20", 17999.99m, "256GB Storage, 8GB RAM, 4300mAh Battery"),
                ("Galaxy M32", 3999.99m, "64GB Storage, 6GB RAM, 6000mAh Battery")
            }},
            { "Apple", new List<(string, decimal, string)> {
                ("iPhone 13", 14499.99m, "128GB Storage, A15 Bionic Chip, 3240mAh Battery"),
                ("iPhone 13 Pro", 17999.99m, "256GB Storage, A15 Bionic Chip, 3095mAh Battery"),
                ("iPhone SE", 7699.99m, "64GB Storage, A15 Bionic Chip, 1821mAh Battery"),
                ("iPhone 12", 12699.99m, "128GB Storage, A14 Bionic Chip, 2815mAh Battery")
            }},
            { "Google", new List<(string, decimal, string)> {
                ("Pixel 6", 10899.99m, "128GB Storage, 8GB RAM, 4614mAh Battery"),
                ("Pixel 6 Pro", 16299.99m, "128GB Storage, 12GB RAM, 5003mAh Battery"),
                ("Pixel 5a", 8129.99m, "128GB Storage, 6GB RAM, 4680mAh Battery")
            }},
            { "Huawei", new List<(string, decimal, string)> {
                ("P50 Pro", 21699.99m, "256GB Storage, 8GB RAM, 4360mAh Battery"),
                ("Mate 40 Pro", 19799.99m, "256GB Storage, 8GB RAM, 4400mAh Battery"),
                ("Nova 9", 8999.99m, "128GB Storage, 8GB RAM, 4300mAh Battery"),
                ("MatePad 11", 5999.99m, "128GB Storage, 6GB RAM, 7250mAh Battery")
            }}
        };

        Console.WriteLine("Welcome : choose the Smartphone you want!");

        // Prompt the user to choose a brand by name
        Console.WriteLine("Available Brands:");
        foreach (var brand in cellphoneInventory.Keys)
        {
            Console.WriteLine(brand);
        }

        Console.Write("Please enter the name of the brand: ");
        string chosenBrand = Console.ReadLine()?.Trim().ToLower();

        string matchedBrand = null;
        foreach (var brand in cellphoneInventory.Keys)
        {
            if (brand.ToLower() == chosenBrand)
            {
                matchedBrand = brand;
                break;
            }
        }

        if (!string.IsNullOrEmpty(matchedBrand))
        {
            Console.WriteLine($"\nYou chose {matchedBrand}.");
            Console.WriteLine("Available Models:");

            // Display available models for the chosen brand
            List<(string Model, decimal Price, string Specs)> models = cellphoneInventory[matchedBrand];
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} - R{models[i].Price}");
            }

            Console.Write("Please choose a model by entering the number: ");
            if (int.TryParse(Console.ReadLine(), out int modelChoice) && modelChoice > 0 && modelChoice <= models.Count)
            {
                var chosenModel = models[modelChoice - 1];
                Console.WriteLine($"\nYou chose {chosenModel.Model}.");

                // Create and display the chosen smartphone
                Smartphone selectedPhone = new Smartphone(matchedBrand, chosenModel.Model, chosenModel.Price, chosenModel.Specs);
                selectedPhone.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Invalid model choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid brand name.");
        }

        Console.WriteLine("Thank you !");
    }
}
