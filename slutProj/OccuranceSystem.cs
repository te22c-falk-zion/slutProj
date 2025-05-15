public class OccuranceSystem {
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
        if(Random.Shared.Next(1,5)==1)
        {
            Console.WriteLine("A random occurance has started!");
            Console.WriteLine("Avaible Occurances:\nHeal occurance\nBuff occurance\nNerf occurance");
            Console.WriteLine("Generating occruance...");
            Console.ReadLine();
            Console.Clear();
            int randomOccurance = random.Next(1,4);
            switch (randomOccurance)
            {
                case 1:
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
                Console.WriteLine("Buff Occurance generated");
                rewardSystem.RewardBuff(1);
                Console.ReadLine();
                Console.Clear();
                break;
                case 3:
                Console.WriteLine("Nerf Occurance generated (not finished)");
                int randomNerf = Random.Shared.Next(0,2);
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
        float saveHP = target.GetFighterFloat("Health");
        float HPChange = target.GetFighterFloat("Health")/100 * percent;
        float healHealth = target.GetFighterFloat("Health");
        target.SetFighterFloat("Health", saveHP + HPChange);

        if (target.GetFighterFloat("Health") > target.GetFighterFloat("MaxHealth"))
        {
            target.SetFighterFloat("Health", target.GetFighterFloat("MaxHealth"));
        }
        if (target.GetFighterFloat("Health") == 0)
        {
            target.SetFighterFloat("Health",1);
        }

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