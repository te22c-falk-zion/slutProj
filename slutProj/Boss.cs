public class Boss : Enemy
{

    //Initialisering.
    public Boss(string name, float maxHP, float HP, float ATK, float SPD, float AV, float level = 1)
    : base(name, maxHP, HP, ATK, SPD, AV)
    {
        this.level = level;
    }

    public void BossAttack(Fighter target)
    {
        //En upgraderas atatck som bara bossen kan göra som också sänker ultimate energy.
        //Använder "is hero heroTarget" så att jag kan använda getherostats och setherostats.
        if (target is Hero heroTarget)
        {
        Console.WriteLine($"{GetFighterName()} unleashes a massive attack that removes Ult Energy!!");
        float finalDamage = GetFighterFloat("Attack") * (Random.Shared.Next(120,180)/100);
        float currentHealth = target.GetFighterFloat("Health");
        float currentEnergy = heroTarget.GetHeroStats("UltEnergy");
        heroTarget.SetFighterFloat("Health", currentHealth - finalDamage);
        heroTarget.SetHeroStats("UltEnergy",currentEnergy - 30);
        }

    }

    public override void LevelUp(float stage)
    {
        //En bättre version av Enemyns level up som har bättre scaling och är lite för stark (2x starkare).
        float currentAttack = GetFighterFloat("Attack");
        float currentHealth = GetFighterFloat("Health");
        float currentSpeed = GetFighterFloat("Speed");
        level += stage;
        currentHealth += GetFighterFloat("Health")*level;
        currentAttack += GetFighterFloat("Attack")*level;
        currentSpeed += level/10 * 8;
        SetFighterFloat("Health", currentHealth);
        SetFighterFloat("Attack", currentAttack);
        SetFighterFloat("Speed", currentSpeed);
    }
}