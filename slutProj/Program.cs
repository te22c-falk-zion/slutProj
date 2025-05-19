using System;
using System.Collections;

//skapar dina heroes.
List<Hero> heroes = new()
{
    new Hero("Seele",1800,1800,2300,124,0,80,160,100,300,300,0),
    new Hero("Yanqing",2000,2000,1400,134,0,20,300,120,200,400,0),
    new Hero("Blade",5000,5000,1500,95,0,50,180,100,300,300,0),
    new Hero("Kafka",2400,2400,1800,134,0,60,150,120,200,400,0)
};

//Initialiserar lists, klasser, floats och bools.
List<Enemy> enemies = new List<Enemy>(); 
rewardSystem reward = new rewardSystem(heroes, enemies);
OccuranceSystem occurance = new OccuranceSystem(heroes, reward);
Menu menu = new Menu();
float stage = 1;
bool gameLoop = true;


//startar tutorial texten genom menu klassen.
menu.Intro(1);
while (gameLoop == true)
{
    
    //skriver main menu texten genom mainmenu metoden.
    int choiceInt = menu.MainMenuChoose(stage);


    //Beroende på vad man skrev ovan så väljer den en av de 4 under.
    switch (choiceInt)
    {
        //ger en buff, har en chans att starta en occurance, skapar en lista med enemies
        // Skapar en combat klass med dina heroes och nya enemies och börjar combat
        //Om du vinner får du en reward och en till chans på en occurance. TIll sist går stage up med en.
        case 1:
            occurance.OccuranceStart();
            enemies = EnemySpawner.CreateEnemies(stage);
            BattleSystem combat = new BattleSystem(heroes, enemies);
            combat.InBattle(reward);
            enemies.Clear();            
            reward.RewardBuff(1);
            occurance.OccuranceStart();
            stage++;
        break;
        //Gör metod UseDisplay.
        case 2:
            reward.BuffList.UseDisplay();
        break;
        //Gör metod Help.
        case 3:
         menu.Help();
        break;
        //Gör gameLoop false som stänger spelet.
        case 4:
            gameLoop = false;
        break;
    }


}
Console.WriteLine("Goodbye!");
Console.ReadLine();