public class Item
{
    //Initialisering.
    public string Name { get ; set; }
    public string itemBio { get; set; }

    public Item (string Name, string bio)
    {
        this.Name = Name;
        itemBio = bio;
    }

    //Virtual void för om man använder ett item inom UseDisplay.
    public virtual void Use()
    {
        Console.WriteLine($"This does not have a use.");
        Console.ReadLine();
    }
}