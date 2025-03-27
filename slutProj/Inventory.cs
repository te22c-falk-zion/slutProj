public class Inventory
{
    public List<Buff> buffs = [];

    public void Display()
    {
        for (int i = 0; i < buffs.Count; i++)
        {
            Console.WriteLine($"{i+1} {buffs[i].Name}");
        }
        Console.ReadLine();
    }
    

}