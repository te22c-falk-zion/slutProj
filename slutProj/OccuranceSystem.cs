public class OccuranceSystem {

    //Initialisering
    Random random = new();
    private List<Fighter> fighters;
    private  rewardSystem rewardSystem;
    
    public OccuranceSystem(List<Hero> heroes, rewardSystem reward)
    {
        fighters = new List<Fighter>();
        fighters.AddRange(heroes);
        rewardSystem = reward;
    }


    public void OccuranceStart()
    {

        //Skapar ett random number om det är 1 gör resten av metoden annars gör inget.
        if(Random.Shared.Next(1,5)==1)
        {
            Console.WriteLine("A random occurance has started!");
            Console.WriteLine("Avaible Occurances:\nHeal occurance\nBuff occurance\nNerf occurance");
            Console.WriteLine("Generating occruance...");
            Console.ReadLine();
            Console.Clear();

            //skapar ett nytt random number för att betsämma vilken occurance som händer.
            int randomOccurance = random.Next(1,4);
            switch (randomOccurance)
            {
                case 1:
                //Använder samma metod för att ta bort hp för att ge HP med ett procent.
                Console.WriteLine("Heal Occurance generated");
                List<Hero> healTargets = fighters.OfType<Hero>().Where(h => h is Hero && h.GetFighterFloat("Health") > 0).ToList();
                for (int i = 0; i < healTargets.Count; i++)
                {
                    ChangeHp(healTargets[i], 50);
                    Console.ReadLine();   
                }
                Console.Clear();
                Console.WriteLine("All heroes have been healed!");
                Console.ReadLine();
                break;
                case 2:
                //Ger playern en buff
                Console.WriteLine("Buff Occurance generated");
                rewardSystem.RewardBuff(1);
                Console.ReadLine();
                Console.Clear();
                break;
                case 3:
                
                Console.WriteLine("Nerf Occurance generated");
                //(det var planerat att ha 2 olika nerfs därför skapar den ett random nummer)
                int randomNerf = Random.Shared.Next(1,3);
                
                //Använder samma metod för healing för att ta bort HP med ett procent.
                if (randomNerf == 1)
                {
                    Random rnd = new Random();
                    List<Hero> randomTargets = fighters.OfType<Hero>().Where(h => h is Hero && h.GetFighterFloat("Health") > 0).ToList();
                    Hero randomTarget = randomTargets[rnd.Next(randomTargets.Count)];
                    ChangeHp(randomTarget, -20);
                }
                if (randomNerf == 2)
                {
                    Console.WriteLine("You're lucky this nerf isn't implemented yet...");
                }
                Console.ReadLine();
                break;
            }
        }
        else
        {
            Console.WriteLine("No occurance was generated...");
            Console.ReadLine();
        }
    }

    private void ChangeHp(Fighter target, float percent)
    {
        //Sparar herons hp innan något händer för att visa senare.
        float saveHP = target.GetFighterFloat("Health");

        //Applicerar hp heal/drain och sätter herons hp som det.
        float HPChange = target.GetFighterFloat("Health")/100 * percent;
        target.SetFighterFloat("Health", saveHP + HPChange);

        // Ser till så att herons HP inte går över deras max eller att dom dör.
        if (target.GetFighterFloat("Health") > target.GetFighterFloat("MaxHealth"))
        {
            target.SetFighterFloat("Health", target.GetFighterFloat("MaxHealth"));
        }
        if (target.GetFighterFloat("Health") == 0)
        {
            target.SetFighterFloat("Health",1);
        }

        //Skriver annorlunda text beroende på om ditt är under eller över det sparade saveHP tidigare i metoden.
        if(target.GetFighterFloat("Health") > saveHP)
        {
        Console.WriteLine($"{target.GetFighterName()} healed by {HPChange}.");
        Console.WriteLine($"{saveHP} --> {target.GetFighterFloat("Health")}");
        }
        if (target.GetFighterFloat("Health") < saveHP)
        {
            Console.WriteLine($"{target.GetFighterName()} lost {HPChange} health.");
            Console.WriteLine($"{saveHP} --> {target.GetFighterFloat("Health")}");
        }
    }
}