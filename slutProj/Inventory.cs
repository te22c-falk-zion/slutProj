using System.Runtime.CompilerServices;

public class Inventory
{
    public List<Item> items = [];
    private int maxItems;

    public void Display()
    {
        maxItems = items.Count;
        Console.WriteLine("\nDisplaying Buffs:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i+1}. {items[i].Name}");
        }
        Console.ReadLine();
    }
    public void UseDisplay()
    {
        int inspectInt = 20;
        string inspectString = "a";
        
        while(!inspectString.All(char.IsDigit) || inspectInt > maxItems || inspectInt <= 0)
        {
            Display();
            Console.WriteLine($"Select what to inspect");
            Console.WriteLine($"Type 0 to quit.");
            inspectString = Console.ReadLine();
            inspectInt = int.TryParse(inspectString, out inspectInt) ? inspectInt : 0;
            if (inspectInt == 0)
            {
                break;
            }
            Console.Clear();
        }
        if (inspectInt != 0)
        {
        items[inspectInt-1].Use();
        }
        
    }
    
    public Inventory()
    {
        maxItems = items.Count;
    }

}