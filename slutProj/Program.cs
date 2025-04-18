﻿using System;
using System.Media;
using System.Runtime.CompilerServices;


List<Enemy> enemies = new List<Enemy>(); 
Hero player = new Hero { Name = "Seele", maxHP = 3000, HP = 3000, ATK = 2000, SPD = 124, CR = 80, CD = 150, NorMult = 100, SkiMult = 200, UltMult = 400 };
Hero player2 = new Hero { Name = "Yanqing", maxHP = 3000, HP = 3000, ATK = 2000, SPD = 95, CR = 20, CD = 300, NorMult = 100, SkiMult = 200, UltMult = 400 };

List<Hero> heroes = new();
heroes.Add(player);
heroes.Add(player2);
rewardSystem reward = new rewardSystem(heroes, enemies);
OccuranceSystem occurance = new OccuranceSystem(heroes, reward);

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
            occurance.OccuranceStart();
            enemies.AddRange(new List<Enemy>
            {
                new Enemy { Name = "Goblin", HP = 25000, ATK = 100, SPD = 90},
                new Enemy { Name = "Goblin2", HP = 25000, ATK = 100, SPD = 90}
            });
            enemies.ForEach(e => e.LevelUp(stage));
            BattleSystem combat = new BattleSystem(heroes, enemies);
            combat.InBattle(reward);            
            reward.RewardBuff();
            stage++;
            occurance.OccuranceStart();
        break;
        case 2:
            reward.BuffList.Display();
        break;
        case 3:
            while(!tutorialString.All(char.IsDigit) && TutorialInt >= 6 || choiceInt <= 0)
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
            Tutorial(TutorialInt);
        break;
        case 4:
            gameLoop = false;
        break;
    }


}
Console.WriteLine("Goodbye!");
Console.ReadLine();


void Tutorial(int var)
{   
        
    if (var == 1 || var == 2)
    {
        Console.WriteLine("-- Welcome to NOT star rail --");
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
    if (var == 1 || var == 6)
    {
        Console.WriteLine("-- Buffs --");
        Console.WriteLine("Buffs are items picked up that increase the strenght of your heroes.");
        Console.WriteLine("Buffs can be obtained randomly in occurances or when winning battles.");
        Console.ReadLine();
    }
    if (var == 1 || var == 7)
    {
        Console.WriteLine("-- Occurances --");
        Console.WriteLine("Occurances randomly occur on either the start or end of your figths.");
        Console.WriteLine("Occurances can either heal, buff or nerf you depending on what you get.");
        Console.ReadLine();
    }
}