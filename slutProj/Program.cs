using System;
using System.Media;
using System.Runtime.CompilerServices;


List<Enemy> enemies = new List<Enemy>(); 
List<Hero> heroes = new();
heroes.AddRange(new List<Hero> 
{
    new Hero { Name = "Seele", maxHP = 1800, HP = 1800, ATK = 2300, SPD = 124, CR = 80, CD = 160, NorMult = 100, SkiMult = 300, UltMult = 300 },
    new Hero { Name = "Yanqing", maxHP = 2000, HP = 2000, ATK = 1000, SPD = 134, CR = 20, CD = 300, NorMult = 120, SkiMult = 200, UltMult = 400 },
    new Hero { Name = "Blade", maxHP = 5000, HP = 5000, ATK = 1000, SPD = 95, CR = 50, CD = 180, NorMult = 100, SkiMult = 300, UltMult = 300 },
    new Hero { Name = "Kafka", maxHP = 2400, HP = 2400, ATK = 1800, SPD = 134, CR = 60, CD = 150, NorMult = 120, SkiMult = 200, UltMult = 400 }
});

rewardSystem reward = new rewardSystem(heroes, enemies);
OccuranceSystem occurance = new OccuranceSystem(heroes, reward);
Tutorial tutorial = new Tutorial();

float stage = 1;
bool gameLoop = true;
tutorial.Intro(1);

while (gameLoop == true)
{
    Console.Clear();
    string choiceString = "a";
    int choiceInt = 10;
    string tutorialString = "a";
    int TutorialInt = 10;
    

    while (!choiceString.All(char.IsDigit) && choiceInt >= 5 || choiceInt <= 0)
    {   
        Console.Clear();
        Console.WriteLine($"Stage: {stage}");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("Type the number corresponding to your choice.");
        Console.WriteLine("1. Fight");
        Console.WriteLine("2. Check Bag");
        Console.WriteLine("3. Help");
        Console.WriteLine("4. Quit");
        choiceString = Console.ReadLine();
        choiceInt = int.TryParse(choiceString, out choiceInt) ? choiceInt : 0;
    }
    switch (choiceInt)
    {
        case 1:
            
            occurance.OccuranceStart();
            enemies.AddRange(new List<Enemy>
            {
                new Enemy { Name = "Goboblin", HP = 25000, ATK = 100, SPD = 90},
                new Enemy { Name = "Goblito", HP = 25000, ATK = 100, SPD = 90},
                new Enemy { Name = "Gobleta", HP = 25000, ATK = 100, SPD = 90},
                new Enemy { Name = "Jonathan", HP = 25000, ATK = 100, SPD = 90}
            });
            enemies.ForEach(e => e.LevelUp(stage));
            BattleSystem combat = new BattleSystem(heroes, enemies);
            combat.InBattle(reward);            
            reward.RewardBuff(1);
            stage++;
            occurance.OccuranceStart();
        break;
        case 2:
            reward.BuffList.UseDisplay();
        break;
        case 3:
            while(!tutorialString.All(char.IsDigit) && TutorialInt >= 6 || TutorialInt <= 0)
            {
                Console.WriteLine("What do you need help with?");
                Console.WriteLine("If you want to see the Entire Turorial again type 1.");
                Console.WriteLine("If you want to see the Game Description again type 2.");
                Console.WriteLine("If you want to see the Normal Attack again type 3.");
                Console.WriteLine("If you want to see the Skill Attack again type 4.");
                Console.WriteLine("If you want to see the Ultimate Attack again type 5.");
                Console.WriteLine("If you want to see the Buff Tutorial again type 6.");
                Console.WriteLine("If you want to see the Occurance Tutorial again type 7.");
                tutorialString = Console.ReadLine();
                TutorialInt = int.TryParse(tutorialString, out TutorialInt) ? TutorialInt : 0;
            }
            tutorial.Intro(TutorialInt);
        break;
        case 4:
            gameLoop = false;
        break;
    }


}
Console.WriteLine("Goodbye!");
Console.ReadLine();