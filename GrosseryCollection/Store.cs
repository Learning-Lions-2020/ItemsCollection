
public class Store
{
    private List<IStoreItem> inventory = new List<IStoreItem>();

    public event EventHandler<string> OnItemSold;

    public delegate void ItemSoldHandler(IStoreItem item); // non generic delegate


    public void AddItem<T>(T item) where T : IStoreItem
    {
        inventory.Add(item);
        Console.WriteLine($"Added {item.Name} to inventory.");
    }

    public void SellItem<T>(T item, ItemSoldHandler<T> handler) where T : IStoreItem
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            handler(item);
            OnItemSold?.Invoke(this, item.Name);
        }
        else
        {
            Console.WriteLine($"{item.Name} is not available in inventory.");
        }
    }

    // Non-generic method to sell an item using a non-generic delegate
    public void SellItem(IStoreItem item, ItemSoldHandler handler)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            handler(item); // Call the non-generic delegate
            OnItemSold?.Invoke(this, item.Name); 
        }
        else
        {
            Console.WriteLine($"{item.Name} is not available in inventory.");
        }
    }


    // Display current inventory
    public void ShowInventory()
    {
        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"- {item.Name} (KES {item.Price})");
        }
        Console.WriteLine();
    }
}
