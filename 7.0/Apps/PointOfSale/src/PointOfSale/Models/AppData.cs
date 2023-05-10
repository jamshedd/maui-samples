namespace PointOfSale.Models;

public static class AppData
{
    private static Random random = new Random();
    public static string[] Statuses = new string[] { "Ready to Pay", "Cooking", "Ready to Order" };
    public static List<int> Tables = new List<int> { 7,8,9,10,11,12,13,14 };

    public static List<Item> Items = new List<Item>
    {
        new Item(){ Title = "Tomato Soup", Price = 4.00, Quantity = 1, Category = ItemCategory.Starters, Image = "tomatosoup.jpg"},
        new Item(){ Title = "Clam Chowder", Price = 4.50, Quantity = 1, Category = ItemCategory.Starters, Image = "clamchowder.jpg"},
        new Item(){ Title = "Idli Sambar", Price = 3.00, Quantity = 1, Category = ItemCategory.Starters, Image = "idlisambar.jpg"},
        new Item(){ Title = "Kothambir Vadi", Price = 2.50, Quantity = 1, Category = ItemCategory.Starters, Image = "kothambirvadi.jpg"},
        new Item(){ Title = "Oysters", Price = 7.00, Quantity = 1, Category = ItemCategory.Starters, Image = "oysters.jpg"},
        new Item(){ Title = "Pani Puri", Price = 6.00, Quantity = 1, Category = ItemCategory.Starters, Image = "panipuri.jpg"},

        new Item(){ Title = "Pork Dumplings", Price = 6.50, Quantity = 1, Category = ItemCategory.Main, Image = "dumplings.jpg"},
        new Item(){ Title = "Baked Fish", Price = 6.00, Quantity = 1, Category = ItemCategory.Main, Image = "fish.jpg"},
        new Item(){ Title = "Chola Bhatura", Price = 7.00, Quantity = 1, Category = ItemCategory.Main, Image = "cholabhatura.jpg"},
        new Item(){ Title = "Flat Noodles", Price = 5.95, Quantity = 1, Category = ItemCategory.Main, Image = "flatnoodles.jpg"},
        new Item(){ Title = "Ramen", Price = 4.50, Quantity = 1, Category = ItemCategory.Main, Image = "ramen.jpg"},
        new Item(){ Title = "Fried Wontons", Price = 4.00, Quantity = 1, Category = ItemCategory.Main, Image = "friedwontons.jpg"},
        new Item(){ Title = "Ham, Egg, and Roasted Potatoes", Price = 6.00, Quantity = 1, Category = ItemCategory.Main, Image = "hameggpotatoes.jpg"},
        new Item(){ Title = "Chola Bhatura", Price = 6.00, Quantity = 1, Category = ItemCategory.Main, Image = "cholabhatura.jpg"},
        new Item(){ Title = "Pav Bhaji", Price = 6.00, Quantity = 1, Category = ItemCategory.Main, Image = "pavbhaji.jpg"},
        new Item(){ Title = "Sushi", Price = 4.50, Quantity = 1, Category = ItemCategory.Main, Image = "sushi.jpg"},
        new Item(){ Title = "Thali", Price = 12.00, Quantity = 1, Category = ItemCategory.Main, Image = "thali2.jpg"},
        new Item(){ Title = "Thali (Meat)", Price = 18.00, Quantity = 1, Category = ItemCategory.Main, Image = "thalimeat.jpg"},

        new Item(){ Title = "Baklava", Price = 3.00, Quantity = 1, Category = ItemCategory.Desserts, Image = "baklava.jpg"},
        new Item(){ Title = "Brownie", Price = 2.00, Quantity = 1, Category = ItemCategory.Desserts, Image = "brownie.jpg"},
        new Item(){ Title = "Cheese Cake", Price = 3.00, Quantity = 1, Category = ItemCategory.Desserts, Image = "cheesecake.jpg"},
        new Item(){ Title = "Assorted Chocolates", Price = 2.50, Quantity = 1, Category = ItemCategory.Desserts, Image = "chocolates.jpg"},
        new Item(){ Title = "Chocolate Sundae", Price = 5.50, Quantity = 1, Category = ItemCategory.Desserts, Image = "chocolatesundae.jpg"},
        new Item(){ Title = "Gulab Jamun", Price = 4.00, Quantity = 1, Category = ItemCategory.Desserts, Image = "gulabjamun.jpg"},
        new Item(){ Title = "Apple Pie", Price = 4.00, Quantity = 1, Category = ItemCategory.Desserts, Image = "pie.jpg"},
        new Item(){ Title = "Ladoo", Price = 1.50, Quantity = 1, Category = ItemCategory.Desserts, Image = "ladoo.jpg"},
        new Item(){ Title = "Modak", Price = 1.50, Quantity = 1, Category = ItemCategory.Desserts, Image = "modak.jpg"},
        new Item(){ Title = "Karanji", Price = 1.75, Quantity = 1, Category = ItemCategory.Desserts, Image = "karanji.jpg"},

        new Item(){ Title = "Coffee", Price = 4.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "coffeeandcroissant.jpg"},
    };
    
    public static List<Order> Orders { get; set; } = GenerateOrders();

    private static List<Order> GenerateOrders()
    {
        random.Shuffle(Tables);
        List<Order> orders = new List<Order>();
        for (int i = 0; i < Tables.Count; i++)
        {
            orders.Add((new Order()
            {
                Table = Tables[i],
                Status = RandomStatus(),
                Items = GenerateItems()
            }));
        }

        orders.OrderByDescending(x => x.Status);
        return orders;
    }

    private static List<Item> GenerateItems()
    {
        List<Item> items = new List<Item>(); 
        int numItems = random.Next(1, Items.Count - 1);
        random.Shuffle(Items);
        for (int i = 0; i < numItems; i++)
        {
            items.Add(Items[i]);
        }

        return items;
    }

    private static string RandomStatus()
    {
        var i = random.Next(0, Statuses.Length - 1);
        return Statuses[i];
    }
}

static class RandomExtensions
{
    public static void Shuffle<T> (this Random rng, List<T> array)
    {
        int n = array.Count;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}