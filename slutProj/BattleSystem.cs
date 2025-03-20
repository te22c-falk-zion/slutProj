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
        string choiceString = "a";
        int choiceInt = 10;
        Console.WriteLine($"It is {hero.Name}'s turn!");
        Console.WriteLine("1. Normal Attack  2. Skill Attack  3. Ultimate Attack");

        // Attackerar den förta enemy:n inom listan eftersom jag har inte kommit runt till att skriva kod för att välja. Det kommer senare.
        Enemy target = fighters.OfType<Enemy>().FirstOrDefault(e => e.HP > 0);
        if (target == null) return;


        //While loop så att man inte kan på någpt sätt skriva fel och inte ha sin tur
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
        Console.WriteLine($"{target.Name}'s HP: {target.HP}");
        Console.ReadLine();
    }
    public void EnemyTurn(Enemy enemy)
    {
        //Atteckerar första Hero:n i listan fighters. Ska utveckla och göra det slumpmässigt senare.
        Hero target = fighters.OfType<Hero>().FirstOrDefault(h => h.HP > 0);
        if (target == null) return;

        Console.WriteLine($"It is {enemy.Name}'s turn!");
        Console.ReadLine();
        enemy.Attack(target);
        enemy.AV = 10000/ enemy.SPD;
        Console.WriteLine($"{target.Name}'s HP: {target.HP}");
    }
}