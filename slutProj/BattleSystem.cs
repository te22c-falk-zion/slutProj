using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


public class BattleSystem 
{
    private List<Fighter> fighters;
    private int skillPoints = 3;
    public BattleSystem(List<Hero> heroes, List<Enemy> enemies)
    {
        fighters = new List<Fighter>();
        fighters.AddRange(heroes);
        fighters.AddRange(enemies);

        //Skapar AV värde för allt i fighters listan.        
        fighters.ForEach(f => f.AV = 10000/f.SPD);
    }

    public void InBattle(rewardSystem reward)
    {   
        skillPoints = 3;
        ApplyBuffs(reward);
        Console.ReadLine();
        //Skapar en while loop för när någon i bege listorna är levande
        while(fighters.Any(h => h is Hero && h.HP > 0) && fighters.Any(e => e is Enemy && e.HP > 0))
        {
            //Anordnar fighters listan från lägst AV value och sen gör det till listan.
            // Den figther som har lägst AV kommer att bli nämnd till currentFigther
            fighters = fighters.Where(f => f.HP > 0).OrderBy(f => f.AV).ToList();
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
        RemoveBuffs(reward);
    }



    public void HeroTurn(Hero hero)
    {
        Console.Clear();
        if (skillPoints > 5) skillPoints = 5;
        float beforeHP;
        string choiceString = "a";
        int choiceInt = 10;
        string targetString = "a";
        int targetInt = 1;
        bool attacklanded = false;
        

        // skapar en ny lista och söker igenom fighters listan för enemy klassen. Dom som de hittar blir då
        // tillagd inom den nya listan
        List<Enemy> aliveTargets = fighters.OfType<Enemy>().Where(e => e.HP > 0).OrderBy(e => e.Name).ToList();

        
    
        //While loop så att man inte kan på något sätt skriva fel och inte ha sin tur
        while (!targetString.All(char.IsDigit) || targetInt <= 0 || targetInt >= aliveTargets.Count +1)
        {
            Console.Clear();
            Console.WriteLine($"It is {hero.Name}'s turn!");
            DisplayFighters();
            Console.WriteLine("Pick who to attack. Type in the number corresponding to the enemy.");
            targetString = Console.ReadLine();
            targetInt = int.TryParse(targetString, out targetInt) ? targetInt : 0;
        }
        
        // Det numret du skrev blir subtraherad med 1 för att listan börjar med 0.
        Enemy target = aliveTargets[targetInt-1];
        beforeHP = target.HP;

        //While loop så att man inte kan på något sätt skriva fel och inte ha sin tur
        while (!choiceString.All(char.IsDigit) && choiceInt >= 4 || choiceInt <= 0)
        {       
            Console.WriteLine($"Skill points:{skillPoints} || {hero.Name}'s Energy: {hero.ultEnergy}");
            Console.WriteLine("1. Normal Attack  2. Skill Attack  3. Ultimate Attack");

            choiceString = Console.ReadLine();
            choiceInt = int.TryParse(choiceString, out choiceInt) ? choiceInt : 0;
            switch (choiceInt)
            {
                case 1:
                    hero.Attack(target);
                    hero.AV = 10000 / hero.SPD;
                    skillPoints++;
                    hero.ultEnergy += 10;
                    attacklanded = true;
                    break;
                case 2:
                    if (skillPoints <= 0) 
                    {
                        choiceInt = 10; 
                        Console.WriteLine("You do not have enough skill points to use skill!"); 
                        Console.WriteLine("Get skill points by using basic attacks.");
                        Console.ReadLine();
                    }
                    if (skillPoints > 0) 
                    {
                        hero.SkiAttack(target);
                        hero.AV = 10000 / hero.SPD;
                        skillPoints--;
                        hero.ultEnergy += 25;
                        attacklanded = true;
                    }
                    break;
                case 3:          
                    if (hero.ultEnergy <= 100)
                    {
                        choiceInt = 10;
                        Console.WriteLine("You do not have enough Ult Energy to Use Ultimate!"); 
                        Console.WriteLine("Get Energy by using attacks and being attacked!");
                        Console.ReadLine();
                    }
                    if(hero.ultEnergy >= 100)
                    {
                        hero.UltAttack(target);
                        hero.AV = 10000 / hero.SPD;
                        hero.ultEnergy -= 100;
                        attacklanded = true;
                    }
                    break;
            }
        }


        
        if (attacklanded == true)
        {
        Console.WriteLine($"{target.Name}'s HP: {beforeHP} --> {target.HP}");
        Fighter nextInLine = fighters[1];
        Console.WriteLine($"Next turn goes to {nextInLine.Name}!");
        Console.ReadLine();
        Console.Clear();
        }
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
        DisplayFighters();
        Console.WriteLine($"{enemy.Name} attacks {target.Name}");
        Console.ReadLine();

        enemy.Attack(target);
        enemy.AV = 10000/ enemy.SPD;
        target.ultEnergy += 15;
        Console.WriteLine($"{target.Name}'s HP:{beforeHP} --> {target.HP}\n{target.Name} Gained +15 Energy.");
        Fighter nextInLine = fighters[1];
        Console.WriteLine($"Next turn goes to {nextInLine.Name}!");
        Console.ReadLine();
        Console.Clear();
    }

    public void ApplyBuffs(rewardSystem reward)
    {
        List<Hero> bufftargets = fighters.OfType<Hero>().Where(h => h is Hero && h.HP > 0).ToList();

        for (int i = 0; i < bufftargets.Count; i++)
        {
            for (int y = 0; y < reward.BuffList.buffs.Count; y++)
            {
                bufftargets[i].SPD += reward.BuffList.buffs[y].SPDbuff;
                bufftargets[i].CR += reward.BuffList.buffs[y].CRbuff;
                bufftargets[i].CD += reward.BuffList.buffs[y].CDbuff;
                bufftargets[i].ATK += reward.BuffList.buffs[y].ATKbuff/100 * bufftargets[i].ATK;
                bufftargets[i].HP += reward.BuffList.buffs[y].HPbuff/100 * bufftargets[i].HP;
                bufftargets[i].maxHP += reward.BuffList.buffs[y].HPbuff/100 * bufftargets[i].maxHP;
            }
        }

    }
    public void RemoveBuffs(rewardSystem reward)
    {
        List<Hero> bufftargets = fighters.OfType<Hero>().Where(h => h is Hero && h.HP > 0).ToList();

        for (int i = 0; i < bufftargets.Count; i++)
        {
            for (int y = 0; y < reward.BuffList.buffs.Count; y++)
            {
                bufftargets[i].SPD -= reward.BuffList.buffs[y].SPDbuff;
                bufftargets[i].CR -= reward.BuffList.buffs[y].CRbuff;
                bufftargets[i].CD -= reward.BuffList.buffs[y].CDbuff;
                bufftargets[i].ATK = bufftargets[i].ATK/((reward.BuffList.buffs[y].ATKbuff/100)+1);
                bufftargets[i].HP = bufftargets[i].HP/((reward.BuffList.buffs[y].HPbuff/100)+1);
                bufftargets[i].maxHP = bufftargets[i].maxHP/((reward.BuffList.buffs[y].HPbuff/100)+1);
            }
        }

    }
    public void DisplayFighters()
    {
        List<Enemy> Enemies = fighters.OfType<Enemy>().Where(e => e.HP > 0).OrderBy(h => h.Name).ToList();
        List<Hero> Heroes = fighters.OfType<Hero>().Where(h => h.HP > 0).OrderBy(h => h.Name).ToList();
        for (int i = 0; i < Enemies.Count; i++)
        {
            Console.Write($"{i+1}. {Enemies[i].Name}: {Enemies[i].HP}HP ");
        }
        Console.WriteLine("\n");
        for (int y = 0; y < Heroes.Count; y++)
        {
            Console.Write($"{y+1}. {Heroes[y].Name}: {Heroes[y].HP}HP ");
        }
        Console.WriteLine("\n");
    }
}