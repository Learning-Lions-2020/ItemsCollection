
using ItemsCollection.Base;

using static Store;
public delegate void ItemSoldHandler<T>(T item) where T : IStoreItem;

class Program
{
    static void Main()
    {
        var store = new Store();

        store.OnItemSold += (sender, itemName) =>
        {
            
            Console.WriteLine($" {itemName} was sold!");
        };

        var book = new Book { Name = "C# in Depth", Price = 3000m, Author = "Jon Skeet" };
        var gadget = new Gadget { Name = "Smart Watch", Price = 5000m, Brand = "TechBrand" };
        var clothing = new Clothing { Name = "T-Shirt", Price = 2000m, Size = "M" };
        var food = new Food { Name = "Organic Apples", Price = 1500m, Suplier = "Njeri"};

        store.AddItem(book);
        store.AddItem(gadget);
        store.AddItem(clothing);
        store.AddItem(food);    

        store.ShowInventory();

        // Delegate: define how to handle item sale
        ItemSoldHandler<Book> bookSold = b =>
        {
            Console.WriteLine($" Sold book: '{b.Name}' by {b.Author} for KES {b.Price}");
        };

        ItemSoldHandler<Gadget> gadgetSold = g =>
        {
            Console.WriteLine($" Sold gadget: {g.Name} ({g.Brand}) for KES {g.Price}");
        };

        // Non-generic delegate for handling item sale
        ItemSoldHandler foodHandler = item =>
        {
            var food = item as Food;
            Console.WriteLine($"[NON-GENERIC] Sold book: {food?.Name} by {food?.Suplier} for ${food?.Price}");
        };

        // Sell items using generic method and delegate
        store.SellItem(book, bookSold);
        store.SellItem(gadget, gadgetSold);

        // Sell item using non-generic delegate
        store.SellItem(food, foodHandler);

        store.ShowInventory();

    }
}
