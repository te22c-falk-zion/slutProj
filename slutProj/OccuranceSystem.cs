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
                    Console.Write($"{healTargets[i].HP} -->");
                    healTargets[i].HP = healTargets[i].maxHP;
                    Console.WriteLine($"{healTargets[i].maxHP}");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.WriteLine("All heroes have been healed!");
                Console.ReadLine();
                break;
                case 2:
                Console.WriteLine("Buff Occurance generated");
                rewardSystem.RewardBuff();
                Console.ReadLine();
                Console.Clear();
                break;
                case 3:
                Console.WriteLine("Nerf Occurance generated (not finished)");
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
}