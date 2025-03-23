public class Item 
{
    public string Name { get ; set; }
    public string itemBio { get; set; }
    public Item (string Name, string bio)
    {
        this.Name = Name;
        itemBio = bio;
    }

    public virtual void Use()
    {
        Console.WriteLine($"This does not have a use.");
    }
}