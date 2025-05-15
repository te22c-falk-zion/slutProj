using System;

List<Hero> heroes = new()
{
    new Hero { Name = "Seele", maxHP = 1800, HP = 1800, ATK = 2300, SPD = 124, CR = 80, CD = 160, NorMult = 100, SkiMult = 300, UltMult = 300 },
    new Hero { Name = "Yanqing", maxHP = 2000, HP = 2000, ATK = 1000, SPD = 134, CR = 20, CD = 300, NorMult = 120, SkiMult = 200, UltMult = 400 },
    new Hero { Name = "Blade", maxHP = 5000, HP = 5000, ATK = 1000, SPD = 95, CR = 50, CD = 180, NorMult = 100, SkiMult = 300, UltMult = 300 },
    new Hero { Name = "Kafka", maxHP = 2400, HP = 2400, ATK = 1800, SPD = 134, CR = 60, CD = 150, NorMult = 120, SkiMult = 200, UltMult = 400 }
};


List<Enemy> enemies = new List<Enemy>(); 
rewardSystem reward = new rewardSystem(heroes, enemies);
OccuranceSystem occurance = new OccuranceSystem(heroes, reward);
Menu menu = new Menu();

float stage = 1;
bool gameLoop = true;


menu.Intro(1);
while (gameLoop == true)
{
    
    int choiceInt = menu.MainMenuChoose(stage);

    switch (choiceInt)
    {
        case 1:
            
            occurance.OccuranceStart();
            enemies = EnemySpawner.CreateEnemies(stage);
            BattleSystem combat = new BattleSystem(heroes, enemies);
            combat.InBattle(reward);
            enemies.Clear();            
            reward.RewardBuff(1);
            stage++;
            occurance.OccuranceStart();
        break;
        case 2:
            reward.BuffList.UseDisplay();
        break;
        case 3:
         menu.Help();
        break;
        case 4:
            gameLoop = false;
        break;
    }


}
Console.WriteLine("Goodbye!");
Console.ReadLine();