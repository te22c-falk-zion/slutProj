using System;
using System.Collections;

List<Hero> heroes = new()
{
    new Hero("Seele",1800,1800,2300,124,0,80,160,100,300,300,0),
    new Hero("Yanqing",2000,2000,1400,134,0,20,300,120,200,400,0),
    new Hero("Blade",5000,5000,1500,95,0,50,180,100,300,300,0),
    new Hero("Kafka",2400,2400,1800,134,0,60,150,120,200,400,0)
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
            reward.RewardBuff(1);
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