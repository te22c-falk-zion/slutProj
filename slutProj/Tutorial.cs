public class Tutorial {


public void Intro(int var)
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
}