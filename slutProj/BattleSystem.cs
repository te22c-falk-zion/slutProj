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
        fighters.ForEach(f => f.AV = 10000/f.SPD);
    }

    public void InBattle()
    {
        while(fighters.Any(h => h is Hero && h.HP > 0) && fighters.Any(e => e is Enemy && e.HP > 0))
        {
            fighters = fighters.OrderBy(f => f.AV).ToList();
            Fighter currentFighter = fighters.First();
            fighters.ForEach(f => f.AV -= currentFighter.AV);
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

        Enemy target = fighters.OfType<Enemy>.FirstOrDefault(e => e.HP > 0);
        if (target == null) return;

        while (!choiceString.All(char.IsDigit) && choiceInt >= 4 || choiceInt <= 0)
        {
            choiceString = Console.ReadLine();
            choiceInt = int.TryParse(choiceString, out choiceInt) ? choiceInt : 0;
        }
        switch (choiceInt)
        {
            case 1:
                hero.Attack(target);
                hero.AV += 10000 / hero.SPD;
                break;
            case 2:
                hero.SkiAttack(target);
                hero.AV += 10000 / hero.SPD;
                break;
            case 3:
                hero.UltAttack(target);
                hero.AV += 10000 / hero.SPD;
                break;
        }
        Console.WriteLine($"{target.HP}'s HP: {target.HP}");
    }
    public void EnemyTurn(Enemy enemy)
    {
        Hero target = fighters.OfType<Hero>.FirstOrDefault(h => h.HP > 0);
        Console.WriteLine($"It is {enemy.Name}'s turn!");
        Console.ReadLine();
        enemy.Attack(target);
        Console.WriteLine($"{target.Name}'s HP: {target.HP}");
    }
}