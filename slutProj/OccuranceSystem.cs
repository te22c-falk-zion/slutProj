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
                List<Hero> healTargets = fighters.OfType<Hero>().Where(h => h is Hero && h.HP > 0).ToList();
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
                    List<Hero> randomTargets = fighters.OfType<Hero>().Where(h => h is Hero && h.HP > 0).ToList();
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
        float saveHP = target.HP;
        float HPChange = (target.maxHP/100) * percent;
        target.HP += HPChange;
        if (target.HP > target.maxHP) target.HP = target.maxHP;
        if (target.HP == 0) target.HP = 1;
        if(target.HP > saveHP)
        {
        Console.WriteLine($"{target.Name} healed by {HPChange}.");
        Console.WriteLine($"{saveHP} --> {target.HP}");
        }
        if (target.HP < saveHP)
        {
            Console.WriteLine($"{target.Name} lost {HPChange} health.");
            Console.WriteLine($"{saveHP} --> {target.HP}");
        }
    }
}