



using System.Reflection;
using System.Runtime.ConstrainedExecution;

public class Hero : Fighter
{
    public float CR;
    public float CD;
    public float NorMult;
    public float SkiMult;
    public float UltMult;

    public override void Attack(Fighter target)
    {
        
        float baseDamage = (NorMult/100)+1 * ATK + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR)+1) == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CRIT!");
            Console.ResetColor();
            float finalDamage = baseDamage * CD/100+1;
            target.HP -= finalDamage;
        }
        else
        {
            float finalDamage = baseDamage;
            target.HP -=  finalDamage;
        }
        
    }
    public virtual void SkiAttack(Enemy target)
    {
        float baseDamage = (SkiMult/100)+1 * ATK + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR)+1) == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CRIT!");
            Console.ResetColor();
            float finalDamage = baseDamage * CD/100+1;
            target.HP -= finalDamage;
        }
        else
        {
            float finalDamage = baseDamage;
            target.HP -=  finalDamage;
        }
    }
    public virtual void UltAttack(Enemy target)
    {
        float baseDamage = (UltMult/100)+1 * ATK + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR)+1) == 1)
        {
            Console.WriteLine("CRIT!");
            float finalDamage = baseDamage * (CD/100)+1;
            target.HP -= finalDamage;
        }
        else
        {
            float finalDamage = baseDamage;
            target.HP -=  finalDamage;
        }
    }
}