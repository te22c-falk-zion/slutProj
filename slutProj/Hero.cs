



using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;

public class Hero : Fighter
{
    private float CR;
    private float CD;
    private float NorMult;
    private float SkiMult;
    private float UltMult;
    private float ultEnergy;

    public Hero(string name, float maxHP, float HP, float ATK, float SPD, float AV, float _CR, float _CD, float _norMult, float _skiMult, float _ultMult, float _ultEnergy)
     :base (name, maxHP, HP, ATK, SPD, AV)
    {
        CR = _CR;
        CD = _CD;
        NorMult = _norMult;
        SkiMult = _skiMult;
        UltMult = _ultMult;
        ultEnergy = _ultEnergy;
    }

    public float GetHeroStats(string heroStats)
    {
        if (heroStats == "Critrate")
        {
            return CR;
        }
                if (heroStats == "CritDamage")
        {
            return CD;
        }
                if (heroStats == "NormalMult")
        {
            return NorMult;
        }
                if (heroStats == "SkillMult")
        {
            return SkiMult;
        }
                if (heroStats == "UltMult")
        {
            return UltMult;
        }
                if (heroStats == "UltEnergy")
        {
            return ultEnergy;
        }
        else return 0;
    }

    public void SetHeroStats(string thing, float value)
    {
        switch (thing)
        {
            case "CritRate":
                CR = value;
                break;
            case "CritDamage":
                CD = value;
                break;
            case "NorMult":
                NorMult = value;
                break;
            case "SkiMult":
                SkiMult = value;
                break;
            case "UltMult":
                UltMult = value;
                break;
            case "UltEnergy":
                ultEnergy = value;
                break;
            default:
                break;
        }
    }
    public override void Attack(Fighter target)
    {
        
        float baseDamage = (NorMult/100)+1 * GetFighterFloat("Attack") + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR+1)) == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CRIT!");
            Console.ResetColor();
            float currentHealth = target.GetFighterFloat("Health");
            float finalDamage = baseDamage * CD/100+1;
            target.SetFighterFloat("Health", currentHealth - finalDamage);
        }
        else
        {
            
            float finalDamage = baseDamage;
            float currentHealth = target.GetFighterFloat("Health");
            target.SetFighterFloat("Health", currentHealth - finalDamage);
        }
        
    }
    public virtual void SkiAttack(Enemy target)
    {
        float baseDamage = (SkiMult/100)+1 * GetFighterFloat("Attack") + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR+1)) == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CRIT!");
            Console.ResetColor();
            float finalDamage = baseDamage * CD/100+1;
            float currentHealth = target.GetFighterFloat("Health");
            target.SetFighterFloat("Health", currentHealth - finalDamage);
        }
        else
        {
            float finalDamage = baseDamage;
            float currentHealth = target.GetFighterFloat("Health");
            target.SetFighterFloat("Health", currentHealth - finalDamage);
        }
    }
    public virtual void UltAttack(Enemy target)
    {
        float baseDamage = (UltMult/100)+1 * GetFighterFloat("Attack") + Random.Shared.Next(5000,10000);
        int roundedCR = (int)Math.Ceiling(CR);
        if (Random.Shared.Next(1,(100/roundedCR+1)) == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CRIT!");
            Console.ResetColor();
            float finalDamage = baseDamage * (CD/100)+1;
            float currentHealth = target.GetFighterFloat("Health");
            target.SetFighterFloat("Health", currentHealth - finalDamage);
        }
        else
        {
            float finalDamage = baseDamage;
            float currentHealth = target.GetFighterFloat("Health");
            target.SetFighterFloat("Health", currentHealth - finalDamage);
        }
    }
}