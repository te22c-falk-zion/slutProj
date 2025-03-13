



using System.Reflection;
using System.Runtime.ConstrainedExecution;

public class Hero 
{
    public string Name;
    public float HP;
    public float ATK;
    public float CR;
    public float CD;
    public float SPD;
    public float AV;
    public float NorMult;
    public float SkiMult;
    public float UltMult;

    public void NorAttack(Enemy target)
    {
        
        float baseDamage = (NorMult/100)+1 * ATK + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR)+1) == 1)
        {
            float finalDamage = baseDamage * CD/100+1;
            target.HP -= finalDamage;
        }
        else
        {
            float finalDamage = baseDamage;
            target.HP -=  finalDamage;
        }
        
    }
    public void SkiAttack(Enemy target)
    {
        float baseDamage = (SkiMult/100)+1 * ATK + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR)+1) == 1)
        {
            float finalDamage = baseDamage * CD/100+1;
            target.HP -= finalDamage;
        }
        else
        {
            float finalDamage = baseDamage;
            target.HP -=  finalDamage;
        }
    }
    public void UltAttack(Enemy target)
    {
        float baseDamage = (UltMult/100)+1 * ATK + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR)+1) == 1)
        {
            float finalDamage = baseDamage * (CD/100)+1;
            target.HP -= finalDamage;
        }
        else
        {
            float finalDamage = baseDamage;
            target.HP -=  finalDamage;
        }
    }
    public void SetAV(Hero target)
    {
        target.AV = 10000/target.SPD;
    }
}