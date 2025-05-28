namespace ItemsCollection.Base;

public class Food : IStoreItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Suplier { get; set; }
}
