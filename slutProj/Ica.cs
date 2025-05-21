public class Ica : Pet
{
    public Ica(string name, float percent)
    : base(name, percent)
    {}

    public override void ChangeHp(Fighter target, float percent)
    {
        if (target is Hero heroTarget)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Follow Up!");
            Console.ResetColor();
            SetPercent(10);
            base.ChangeHp(heroTarget, percent);
            Console.WriteLine($"{GetPetName()} healed {percent}% of {heroTarget.GetFighterName()}'s HP!");
            Console.ReadLine();
        }
        if (target is Enemy enemyTarget)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Follow Up!");
            Console.ResetColor();
            SetPercent(-10);
            base.ChangeHp(enemyTarget, percent);
            Console.WriteLine($"{GetPetName()} dealt {percent}% of {enemyTarget.GetFighterName()}'s HP!");
            Console.ReadLine();
        }
    }
}