using System;
using System.Media;
using System.Runtime.CompilerServices;


// PlayMusic("Reflection.wav");

List<Enemy> enemies = new List<Enemy> { new Enemy { Name = "Goblin", HP = 50000, ATK = 10, SPD = 90 }, new Enemy { Name = "Goblin2", HP = 50000, ATK = 10, SPD = 90 } };
Hero player = new Hero { Name = "Player", HP = 3000, ATK = 2000, SPD = 100, CR = 80, CD = 150, NorMult = 100, SkiMult = 200, UltMult = 400 };
Hero player2 = new Hero { Name = "Player2", HP = 3000, ATK = 2000, SPD = 89, CR = 20, CD = 300, NorMult = 100, SkiMult = 200, UltMult = 400 };

List<Hero> heroes = new();
heroes.Add(player);
heroes.Add(player2);
rewardSystem reward = new rewardSystem(heroes, enemies);
BattleSystem combat = new BattleSystem(heroes, enemies);

int stage = 1;
bool gameLoop = true;
Tutorial(1);

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
            combat.InBattle(reward);
            reward.RewardBuff();
        break;
        case 2:
            reward.BuffList.Display();
        break;
        case 3:
            while(!tutorialString.All(char.IsDigit) && TutorialInt >= 6 || choiceInt <= 0)
            {
            Console.WriteLine("What do you need help with?");
            Console.WriteLine("If you want to see the entire Turorial again type 1.");
            Console.WriteLine("If you want to see the Game Description again type 2.");
            Console.WriteLine("If you want to see the Normal Attack again type 3.");
            Console.WriteLine("If you want to see the Skill Attack again type 4.");
            Console.WriteLine("If you want to see the Ultimate Attack again type 5.");
            tutorialString = Console.ReadLine();
            TutorialInt = int.TryParse(tutorialString, out TutorialInt) ? TutorialInt : 0;
            }
            Tutorial(TutorialInt);
        break;
        case 4:
            gameLoop = false;
        break;
    }


}
Console.WriteLine("Goodbye!");
Console.ReadLine();


// static void PlayMusic(string filename)
// {
//     SoundPlayer musicPlayer = new SoundPlayer();
//     musicPlayer.SoundLocation = filename;
//     musicPlayer.PlayLooping();
// }

void Tutorial(int var)
{   
        
    if (var == 1 || var == 2)
    {
        Console.WriteLine("Welcome to NOT star rail");
        Console.WriteLine("In this game you will fight against enemies until both your hereos are dead.");
        Console.WriteLine("Clearing a wave will reward you with a selection of buffs to choose from.");
        Console.ReadLine(); 
    }
    if (var == 1 || var == 3)
    {
        Console.WriteLine("-- Normal Attack --");
        Console.WriteLine("Normal attacks deal the least amount of damage in your heroes kit.");
        Console.WriteLine("After using a normal attack you will gain a skill point");
        Console.ReadLine(); 
    }
    if (var == 1 || var == 4)
    {
        Console.WriteLine("-- Skil attack --");
        Console.WriteLine("Skill points are used to cast Skill Attacks!");
        Console.WriteLine("Prioritise using skill atatcks with heroes that have higher damage output to clear waves faster!");
        Console.ReadLine();
    }
    if (var == 1 || var == 5)
    {
        Console.WriteLine("-- Ultimate Attack --");
        Console.WriteLine("Using attacks and getting hit will generate a heroes Ultimate Enegy");
        Console.WriteLine("When Ultimate Energy is full a hero can use their Ultimate Attack to deal HUGE damage to enemies!");
        Console.ReadLine();
    }
}