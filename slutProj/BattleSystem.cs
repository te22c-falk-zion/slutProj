using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;


public class BattleSystem 
{

    //Initialisering.
    private List<Fighter> fighters;
    private List<Pet> summons;
    private int skillPoints = 3;

    public BattleSystem(List<Hero> heroes, List<Enemy> enemies, List<Pet> pets)
    {
        fighters = new List<Fighter>();
        fighters.AddRange(heroes);
        fighters.AddRange(enemies);
        
        summons = new List<Pet>();
        summons.AddRange(pets);

        //Skapar AV värde för allt i fighters listan.
        foreach (Fighter f in fighters)
        {
            // float fAV = f.GetFighterFloat("ActionValue");
            float fSPD = f.GetFighterFloat("Speed");
            f.SetFighterFloat("ActionValue", 100/fSPD);
        }
    }


    //Startar fighten
    public void InBattle(rewardSystem reward)
    {   
        skillPoints = 3;
        ApplyBuffs(reward);
        Console.ReadLine();
        //Skapar en while loop för när någon i bege listorna är levande
        while(fighters.Any(h => h is Hero && h.GetFighterFloat("Health") > 0) && fighters.Any(e => e is Enemy && e.GetFighterFloat("Health") > 0))
        {
            //Anordnar fighters listan från lägst AV value och sen gör det till listan.
            // Den figther som har lägst AV kommer att bli nämnd till currentFigther
            fighters = fighters.Where(f => f.GetFighterFloat("Health") > 0).OrderBy(f => f.GetFighterFloat("ActionValue")).ToList();
            Fighter currentFighter = fighters.First();

            
            // letar inom fighters listan för där f inte är currentfighter och exluderar det från listan. sedan återskapar listan
            // och för allt inom listan (nu finns inte currentfighter) så gör den minus currentFighter.AV på allt.
            foreach (Fighter f in fighters.Where(f => f != currentFighter))
            {
                float fAV = f.GetFighterFloat("ActionValue");
                float currentAV = currentFighter.GetFighterFloat("ActionValue");
                f.SetFighterFloat("ActionValue", fAV - currentAV);
            }
            currentFighter.SetFighterFloat("ActionValue", 0);

            //Om det är herons tur gör starta HeroTurn() metoden.
            if (currentFighter is Hero hero)
                HeroTurn(hero,summons);
            //Annars startsa EnemyTurn() Metoden.
            else if (currentFighter is Enemy enemy)
                EnemyTurn(enemy);
        }
        RemoveBuffs(reward);
    }



    private void HeroTurn(Hero hero, List<Pet> summons)
    {
        // Initialisering av floats och strings.
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
        List<Enemy> aliveTargets = fighters.OfType<Enemy>().Where(e => e.GetFighterFloat("Health") > 0).OrderBy(e => e.GetFighterName()).ToList();

        
    
        //While loop så att man inte kan på något sätt skriva fel och inte ha sin tur
        while (!targetString.All(char.IsDigit) || targetInt <= 0 || targetInt >= aliveTargets.Count +1)
        {
            Console.Clear();
            Console.WriteLine($"It is {hero.GetFighterName()}'s turn!\n");
            DisplayFighters();
            Console.WriteLine($"Skill points:{skillPoints} || {hero.GetFighterName()}'s Energy: {hero.GetHeroStats("UltEnergy")}");
            Console.WriteLine("Pick who to attack. Type in the number corresponding to the enemy.");
            targetString = Console.ReadLine();
            targetInt = int.TryParse(targetString, out targetInt) ? targetInt : 0;
        }
        
        // Det numret du skrev blir subtraherad med 1 för att listan börjar med 0.
        Enemy target = aliveTargets[targetInt-1];
        beforeHP = target.GetFighterFloat("Health");

        //While loop så att man inte kan på något sätt skriva fel och inte ha sin tur
        while (!choiceString.All(char.IsDigit) && choiceInt >= 4 || choiceInt <= 0)
        {       
            Console.WriteLine("1. Normal Attack  2. Skill Attack  3. Ultimate Attack");

            choiceString = Console.ReadLine();
            choiceInt = int.TryParse(choiceString, out choiceInt) ? choiceInt : 0;
            switch (choiceInt)
            {
                case 1:
                    if (skillPoints >= 0)
                    {
                        hero.Attack(target);

                        float hSPD = hero.GetFighterFloat("Speed");
                        hero.SetFighterFloat("ActionValue",10000/hSPD);

                        float hUltE = hero.GetHeroStats("UltEnergy");
                        hero.SetHeroStats("UltEnergy", hUltE + 10);

                        skillPoints++;
                        attacklanded = true;
                    }

                    break;
                case 2:
                    //Checkar om playern har någ med skill pointsör att göra sin skill
                    // Om den har den så gör den sin skill och gör attacklanded true 
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
                        
                        float hSPD = hero.GetFighterFloat("Speed");
                        hero.SetFighterFloat("ActionValue",10000/hSPD);
                        
                        float hUltE = hero.GetHeroStats("UltEnergy");
                        hero.SetHeroStats("UltEnergy", hUltE + 25);
                        
                        skillPoints--;
                        attacklanded = true;
                    }
                    break;
                case 3:         
                    //Checkar om playern har någ men ultenergy för att göra sin ult
                    // Om den har den så gör den sin ult och gör attacklanded true 
                    if (hero.GetHeroStats("UltEnergy") <= 100)
                    {
                        choiceInt = 10;
                        Console.WriteLine("You do not have enough Ult Energy to Use Ultimate!"); 
                        Console.WriteLine("Get Energy by using attacks and being attacked!");
                        Console.ReadLine();
                    }
                    if(hero.GetHeroStats("UltEnergy") >= 100)
                    {
                        hero.UltAttack(target);
                        
                        float hSPD = hero.GetFighterFloat("Speed");
                        hero.SetFighterFloat("ActionValue",10000/hSPD);
                        
                        float hUltE = hero.GetHeroStats("UltEnergy");
                        hero.SetHeroStats("UltEnergy", hUltE - 100);

                        attacklanded = true;
                    }
                    break;
            }
        }


        // Skriver text 
        if (attacklanded == true)
        {
        Console.WriteLine($"{target.GetFighterName()}'s HP: {beforeHP} --> {target.GetFighterFloat("Health")}");
        Fighter nextInLine = fighters[1];
        Console.WriteLine($"Next turn goes to {nextInLine.GetFighterName()}!");
        Console.ReadLine();
        Console.Clear();
        foreach (Pet pet in summons)
        {
            if (Random.Shared.Next(1,3) == 1)
            {
                pet.ChangeHp(target,pet.GetPercent());
            }
            else
            {
                pet.ChangeHp(hero,pet.GetPercent());
            }
        }
        }
    }
    private void EnemyTurn(Enemy enemy)
    {
        Console.Clear();
        
        float beforeHP;
        
        //Samma som ovan. Skapar en ny lista med levande targets men denna gång med heroes.
        // Sedan slumpmässigt väljer vem att attackera.
        List<Hero> aliveTargets = fighters.OfType<Hero>().Where(h => h.GetFighterFloat("Health") > 0).ToList();
        Hero target = aliveTargets[Random.Shared.Next(0,aliveTargets.Count)];
        beforeHP = target.GetFighterFloat("Health");
        if (target == null) return;

        Console.WriteLine($"It is {enemy.GetFighterName()}'s turn!");
        DisplayFighters();
        Console.WriteLine($"{enemy.GetFighterName()} attacks {target.GetFighterName()}");
        Console.ReadLine();
        if (enemy is Enemy enemyTurn)
        {
            enemyTurn.Attack(target);
        }
        else if (enemy is Boss bossTurn)
        {
            if (Random.Shared.Next(1,4) == 1)
            {
                bossTurn.BossAttack(target);
            }
            else
            {
                bossTurn.Attack(target);
            }

        }   
        

        float eSPD = enemy.GetFighterFloat("Speed");
        enemy.SetFighterFloat("ActionValue",10000/eSPD);

        float hUltE = target.GetHeroStats("UltEnergy");
        target.SetHeroStats("UltEnergy", hUltE + 15);


        Console.WriteLine($"{target.GetFighterName()}'s HP:{beforeHP} --> {target.GetFighterFloat("Health")}\n{target.GetFighterName()} Gained +15 Energy.");
        Fighter nextInLine = fighters[1];
        Console.WriteLine($"Next turn goes to {nextInLine.GetFighterName()}!");
        Console.ReadLine();
        Console.Clear();
    }


    private void ApplyBuffs(rewardSystem reward)
    {
        //Skapar en list med alla heroes som kan bli buffad (hp > 0)
        List<Hero> bufftargets = fighters.OfType<Hero>().Where(h => h is Hero && h.GetFighterFloat("Health") > 0).ToList();

        //Gör en for loop för alla heroes i bufftargets och alla buffs inom bufflist
        //Så att varje hero får varje buff.
        for (int i = 0; i < bufftargets.Count; i++)
        {
            for (int y = 0; y < reward.BuffList.items.Count; y++)
            {
                Buff currentBuff = reward.BuffList.items[y] as Buff;
                if (currentBuff != null)
                {

                
                //Skapar en float mwd Get metoder.
                float currentSPD = bufftargets[i].GetFighterFloat("Speed");
                float currentCR = bufftargets[i].GetHeroStats("CritRate");
                float currentCD = bufftargets[i].GetHeroStats("CritDamage");
                float currentATK = bufftargets[i].GetFighterFloat("Attack");
                float currentHP = bufftargets[i].GetFighterFloat("Health");
                float currentMaxHP = bufftargets[i].GetFighterFloat("MaxHealth");

                //Lägger till buffs till den skapade floaten.
                float buffSPD = currentSPD + currentBuff.GetBuff("Speed");
                float buffCR = currentCR + currentBuff.GetBuff("CritRate");
                float buffCD = currentCD + currentBuff.GetBuff("CritDamage");
                float buffATK = currentATK + currentBuff.GetBuff("Attack")/100 * currentATK;
                float buffHP = currentHP + currentBuff.GetBuff("Health")/100 * currentHP;
                float buffMaxHP = currentMaxHP + currentBuff.GetBuff("Health")/100 * currentMaxHP;

                //Applicerar dom genom en Set metod.
                bufftargets[i].SetFighterFloat("Speed", buffSPD);
                bufftargets[i].SetHeroStats("CritRate", buffCR);
                bufftargets[i].SetHeroStats("CritDamage", buffCD);
                bufftargets[i].SetFighterFloat("Attack", buffATK);
                bufftargets[i].SetFighterFloat("Health", buffHP);   
                bufftargets[i].SetFighterFloat("MaxHealth", buffMaxHP);
                }
            }
        }

    }
    private void RemoveBuffs(rewardSystem reward)
    {
        //Skapar en list med alla heroes som kan bli unbuffad (hp > 0)
        List<Hero> bufftargets = fighters.OfType<Hero>().Where(h => h is Hero && h.GetFighterFloat("Health") > 0).ToList();

        for (int i = 0; i < bufftargets.Count; i++)
        {
            for (int y = 0; y < reward.BuffList.items.Count; y++)
            {
            Buff currentBuff = reward.BuffList.items[y] as Buff;
            if (currentBuff != null)
            {
                
                //Skapar en float mwd Get metoder.
                float currentSPD = bufftargets[i].GetFighterFloat("Speed");
                float currentCR = bufftargets[i].GetHeroStats("CritRate");
                float currentCD = bufftargets[i].GetHeroStats("CritDamage");
                float currentATK = bufftargets[i].GetFighterFloat("Attack");
                float currentHP = bufftargets[i].GetFighterFloat("Health");
                float currentMaxHP = bufftargets[i].GetFighterFloat("MaxHealth");

                //Tar bort buffs genom att göra motsattsen av apply buffs metoden.
                float buffSPD = currentSPD - currentBuff.GetBuff("Speed");
                float buffCR = currentCR - currentBuff.GetBuff("CritRate");
                float buffCD = currentCD - currentBuff.GetBuff("CritDamage");
                float buffATK = currentATK/((currentBuff.GetBuff("Attack")/100)+1);
                float buffHP = currentHP/((currentBuff.GetBuff("Health")/100)+1);
                float buffMaxHP = currentMaxHP/((currentBuff.GetBuff("Maxhealth")/100)+1);

                //Applicerar dom genom en Set metod.
                bufftargets[i].SetFighterFloat("Speed", buffSPD);
                bufftargets[i].SetHeroStats("CritRate", buffCR);
                bufftargets[i].SetHeroStats("CritDamage", buffCD);
                bufftargets[i].SetFighterFloat("Attack", buffATK);
                bufftargets[i].SetFighterFloat("Health", buffHP);
                bufftargets[i].SetFighterFloat("MaxHealth", buffMaxHP);
            }
            }
        }

    }
    private void DisplayFighters()
    {
        //Skappar en lista av heroes och enemies som är sorterad inom bokstavsordning.
        List<Enemy> Enemies = fighters.OfType<Enemy>().Where(e => e.GetFighterFloat("Health") > 0).OrderBy(h => h.GetFighterName()).ToList();
        List<Hero> Heroes = fighters.OfType<Hero>().Where(h => h.GetFighterFloat("Health") > 0).OrderBy(h => h.GetFighterName()).ToList();


        //Skriver listorna
        for (int i = 0; i < Enemies.Count; i++)
        {
            Console.Write($"{i+1}. {Enemies[i].GetFighterName()}: {Enemies[i].GetFighterFloat("Health")}HP ");
        }
        Console.WriteLine("\n");
        for (int y = 0; y < Heroes.Count; y++)
        {
            Console.Write($"{y+1}. {Heroes[y].GetFighterName()}: {Heroes[y].GetFighterFloat("Health")}HP ");
        }
        Console.WriteLine("\n");
    }
}