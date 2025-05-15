public class Menu {

public int MainMenuChoose(float stage)
{
    string choiceString = "a";
    int choiceInt = 10;
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
    return choiceInt;
}


public void Help()
{
    string tutorialString = "a";
    int TutorialInt = 10;
    while(!tutorialString.All(char.IsDigit) && TutorialInt >= 6 || TutorialInt < 0)
            {
                Console.WriteLine("What do you need help with?");
                Console.WriteLine("0. Back To Menu");
                Console.WriteLine("1. Entire Tutorial");
                Console.WriteLine("2. Game Description");
                Console.WriteLine("3. Attack Tutorial");
                Console.WriteLine("4. Skill Tutorial");
                Console.WriteLine("5. Ultimate Tutorial");
                Console.WriteLine("6. Buff Tutorial");
                Console.WriteLine("7. Occurance Tutorial");

                tutorialString = Console.ReadLine();
                TutorialInt = int.TryParse(tutorialString, out TutorialInt) ? TutorialInt : 0;
                if (TutorialInt == 0)
                {
                    break;
                }
            }
            Intro(TutorialInt);
}


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