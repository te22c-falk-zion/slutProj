using System.Linq;
using System;
using System.Collections.Generic;



public class rewardSystem 
{
   private List<Fighter> fighters;
   private Random random;
   private List<Buff> buffItems = new List<Buff>
   {
    //Notes for future me!
    //Speed is additive, CR is additive, CD is additive,
    //ATK is multiplicitive, HP is multiplicitave.
    new Buff("Air Jordans",15,0,0,500,500,
    "jordn"),
    new Buff("Lens-Maker's Glasses",0,7,10,100,100,
    "gls"),
    new Buff("Compact Nuke",0,0,75,0,0,
    "nuk"),
    new Buff("Portable Tank",0,0,20,2000,3000,
    "tank"),
    new Buff("Just ATK",0,0,0,4000,0,
    "atk"),
    new Buff("It's my turn.",40,0,0,100,100,
    "tun"),
    new Buff("Filler",0,5,10,200,200,
    "fil"),
    new Buff("Dev Spec",100,50,300,20000,100,
    "spc")
   };

   

    public rewardSystem(List<Hero> heroes, List<Enemy> enemies)
    {
        fighters = new List<Fighter>();
        fighters.AddRange(heroes);
        fighters.AddRange(enemies);
        random = new Random();
    }

    public void RewardBuff()
    {
        string choiceString = "a";
        int choiceInt = 0;
        string answer = "no";
        List<Buff> buffs = GenerateBuffs();

        while (true)
        {
                
            while (!choiceString.All(char.IsDigit) && choiceInt > buffs.Count || choiceInt <= 0)
            {       
                Console.WriteLine($"Total Buffs in buffs: {buffs.Count}");
                Console.WriteLine("You are being rewarded for your efforts.\nThree random items will be generated.\nYou will be able to pick one of these for yourself.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n TIP: You are able to select once to see what buffs they give and then back out if you dont wan't it.");
                Console.ReadLine();
                Console.ResetColor();   
            
                for (int i = 0; i < buffs.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {buffs[i].Name}");
                }
                Console.WriteLine($"Total Buffs in buffItems: {buffs.Count}");
                choiceString = Console.ReadLine();
                choiceInt = int.TryParse(choiceString, out choiceInt) ? choiceInt : 0;
                     

            }

            Console.Clear();
            Console.WriteLine($"{buffs[choiceInt-1].Name}\n\n{buffs[choiceInt-1].itemBio}");
            Console.WriteLine($"Do you want to pick up this item? Yes/No");
            answer = Console.ReadLine().Trim().ToLower();
            if (answer.Equals("no"))
            {
                Console.WriteLine("You did not pick up the item...");
                choiceString = "a";
                choiceInt = 0;
                Console.Clear();
            }
        }



    }
    public void RewardTrade()
    {

    }

    //Skapar en ny lista med en method så vi kan använda den i RewardBuff()
    public List<Buff> GenerateBuffs()
    {
        //skapar en ny lista för att sätta våra buffs
        //Skapar en HashSet eftersom den kan inte ha fler av en interger så vi får olika buffs från listan.
        
        List<Buff> Buffs = new List<Buff>();
        HashSet<int> pickedBuffs = new HashSet<int>();

        //medans buffs listan har mindre än tre items ska den välja en random item från buffitems
        //sedan checka i våran hashset om den int redan finns i listan, om den gör det så gör den om det
        // Om inten är ny blir den inlagd i våran hashset och sedan i våran buffs lista.
        //sist så returnerar den nya listan.
        while (Buffs.Count < 3)
        {
            
            int pickBuff = random.Next(buffItems.Count);
            if(!pickedBuffs.Contains(pickBuff)) 
            {
                pickedBuffs.Add(pickBuff);
                Buffs.Add(buffItems[pickBuff]);
            }
        }
        return Buffs;
    }
}