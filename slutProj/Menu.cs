public class Menu {


//Metoder.

//Menu koden som låter spelaren skriva en int som låter dom välja vad de vill göra.
// Ne tryparse används så att det inte händer några kraschar.
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


//Void som tryparsar vad du skriver och skickar det till Intro() metoden.
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

//Intro method som kallar på specifica delar av tutorial texten beronde på vilken int spelaren la i.
public void Intro(int var)
{   
    if (helpStrings.ContainsKey(var))
        {
            foreach (var text in helpStrings[var])
            {
                Console.WriteLine(text);
            }
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid number.\nQuitting to menu...");
            Console.ReadLine();
        }
}

    //En dictionary med alla tutorialstrings.
    private Dictionary<int, string[]> helpStrings = new Dictionary<int, string[]>
    {
        { 1, new string[] {
            "-- Welcome to NOT star rail --",
            "In this game you will fight against enemies until both your heroes are dead.",
            "Clearing a wave will reward you with a selection of buffs to choose from.",
            "-- Normal Attack --",
            "Normal attacks deal the least amount of damage in your heroes' kit.",
            "After using a normal attack you will gain a skill point.",
            "-- Skill Attack --",
            "Skill points are used to cast Skill Attacks!",
            "Prioritise using skill attacks with heroes that have higher damage output to clear waves faster!",
            "-- Ultimate Attack --",
            "Using attacks and getting hit will generate a hero's Ultimate Energy.",
            "When Ultimate Energy is full a hero can use their Ultimate Attack to deal HUGE damage!",
            "-- Buffs --",
            "Buffs are items picked up that increase the strength of your heroes.",
            "Buffs can be obtained randomly in occurances or when winning battles.",
            "-- Occurrences --",
            "Occurrences randomly occur at the start or end of your fights.",
            "They can either heal, buff, or nerf you depending on what you get."
        }},
        { 2, new string[] {
            "-- Welcome to NOT star rail --",
            "In this game you will fight against enemies until both your heroes are dead.",
            "Clearing a wave will reward you with a selection of buffs to choose from."
        }},
        { 3, new string[] {
            "-- Normal Attack --",
            "Normal attacks deal the least amount of damage in your heroes' kit.",
            "After using a normal attack you will gain a skill point."
        }},
        { 4, new string[] {
            "-- Skill Attack --",
            "Skill points are used to cast Skill Attacks!",
            "Prioritise using skill attacks with heroes that have higher damage output to clear waves faster!"
        }},
        { 5, new string[] {
            "-- Ultimate Attack --",
            "Using attacks and getting hit will generate a hero's Ultimate Energy.",
            "When Ultimate Energy is full a hero can use their Ultimate Attack to deal HUGE damage!"
        }},
        { 6, new string[] {
            "-- Buffs --",
            "Buffs are items picked up that increase the strength of your heroes.",
            "Buffs can be obtained randomly in occurances or when winning battles."
        }},
        { 7, new string[] {
            "-- Occurrences --",
            "Occurrences randomly occur at the start or end of your fights.",
            "They can either heal, buff, or nerf you depending on what you get."
        }}
    };
}