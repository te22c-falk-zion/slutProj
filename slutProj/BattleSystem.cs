using System.Linq;
using System;
using System.Collections.Generic;


public class BattleSystem 
{
    private List<Fighter> fighters;
    public BattleSystem(List<Hero> heroes, List<Enemy> enemies)
    {
        fighters = new List<Fighter>();
        fighters.AddRange(heroes);
        fighters.AddRange(enemies);

        //Skapar AV värde för allt i fighters listan.
        fighters.ForEach(f => f.AV = 10000/f.SPD);
    }

    public void InBattle()
    {   
        //Skapar en while loop för när någon i bege listorna är levande
        while(fighters.Any(h => h is Hero && h.HP > 0) && fighters.Any(e => e is Enemy && e.HP > 0))
        {
            //Anordnar fighters listan från lägst AV value och sen gör det till listan.
            // Den figther som har lägst AV kommer att bli nämnd till currentFigther
            fighters = fighters.OrderBy(f => f.AV).ToList();
            Fighter currentFighter = fighters.First();


            // letar inom fighters listan för där f inte är currentfighter och exluderar det från listan. sedan återskapar listan
            // och för allt inom listan (nu finns inte currentfighter) så gör den minus currentFighter.AV på allt.
            fighters.Where(f => f != currentFighter).ToList().ForEach(f => f.AV -= currentFighter.AV);
            currentFighter.AV = 0;

            if (currentFighter is Hero hero)
                HeroTurn(hero);
            else if (currentFighter is Enemy enemy)
                EnemyTurn(enemy);
        }
    }



    public void HeroTurn(Hero hero)
    {
        Console.Clear();
        float beforeHP;
        string choiceString = "a";
        int choiceInt = 10;
        string targetString = "a";
        int targetInt = 1;
        Console.WriteLine($"It is {hero.Name}'s turn!");

        // skapar en ny lista och söker igenom fighters listan för enemy klassen. Dom som de hittar blir då
        // tillagd inom den nya listan
        List<Enemy> aliveTargets = fighters.OfType<Enemy>().Where(e => e.HP > 0).ToList();
        for (int i = 0; i < aliveTargets.Count; i++)
        {
            Console.WriteLine($"{i+1}. {aliveTargets[i].Name}: {aliveTargets[i].HP} HP");
        }
    
        //While loop så att man inte kan på något sätt skriva fel och inte ha sin tur
        while (!targetString.All(char.IsDigit) || targetInt <= 0 || targetInt >= aliveTargets.Count +1)
        {
            Console.WriteLine("Pick who to attack. Type in the number corresponding to the enemy.");
            targetString = Console.ReadLine();
            targetInt = int.TryParse(targetString, out targetInt) ? targetInt : 0;
        }
        
        // Det numret du skrev blir subtraherad med 1 för att listan börjar med 0.
        Enemy target = aliveTargets[targetInt-1];
        beforeHP = target.HP;
        
        Console.WriteLine("1. Normal Attack  2. Skill Attack  3. Ultimate Attack");

        //While loop så att man inte kan på något sätt skriva fel och inte ha sin tur
        while (!choiceString.All(char.IsDigit) && choiceInt >= 4 || choiceInt <= 0)
        {
            choiceString = Console.ReadLine();
            choiceInt = int.TryParse(choiceString, out choiceInt) ? choiceInt : 0;
        }

        switch (choiceInt)
        {
            case 1:
                hero.Attack(target);
                hero.AV = 10000 / hero.SPD;
                break;
            case 2:
                hero.SkiAttack(target);
                hero.AV = 10000 / hero.SPD;
                break;
            case 3:
                hero.UltAttack(target);
                hero.AV = 10000 / hero.SPD;
                break;
        }
        Console.WriteLine($"{target.Name}'s HP: {beforeHP} --> {target.HP}");
        Console.ReadLine();
    }
    public void EnemyTurn(Enemy enemy)
    {
        Console.Clear();
        float beforeHP;
        
        //Samma som ovan. Skapar en ny lista med levande targets men denna gång med heroes.
        // Sedan slumpmässigt väljer vem att attackera.
        List<Hero> aliveTargets = fighters.OfType<Hero>().Where(h => h.HP > 0).ToList();
        Hero target = aliveTargets[Random.Shared.Next(0,aliveTargets.Count)];
        beforeHP = target.HP;
        if (target == null) return;

        Console.WriteLine($"It is {enemy.Name}'s turn!");
        Console.WriteLine($"{enemy.Name} attacks {target.Name}");
        Console.ReadLine();

        enemy.Attack(target);
        enemy.AV = 10000/ enemy.SPD;
        Console.WriteLine($"{target.Name}'s HP:{beforeHP} --> {target.HP}");
    }
}