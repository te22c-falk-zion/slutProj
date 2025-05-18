public class Enemy : Fighter
{

    //Initialisering.
    protected float level;
    public Enemy(string name, float maxHP, float HP, float ATK, float SPD, float AV, float level = 1)
    : base(name, maxHP, HP, ATK, SPD, AV)
    {
        this.level = level;
    }
    

    //Metoder

    //Attack som tar targets hp och gör random damage till den.
    public override void Attack(Fighter target)
    {
        float finalDamage = GetFighterFloat("Attack") * (Random.Shared.Next(100,150)/100);
        float currentHealth = target.GetFighterFloat("Health");
        target.SetFighterFloat("Health", currentHealth - finalDamage);
    }

    //Tar sina stats och gör dom starkare beroende på vilken stage man är på.
    public virtual void LevelUp(float stage)
    {
        float currentAttack = GetFighterFloat("Attack");
        float currentHealth = GetFighterFloat("Health");
        float currentSpeed = GetFighterFloat("Speed");
        level += stage/2;
        currentHealth += GetFighterFloat("Health")*level;
        currentAttack += GetFighterFloat("Attack")*level;
        currentSpeed += level/10 * 6;
        SetFighterFloat("Health", currentHealth);
        SetFighterFloat("Attack", currentAttack);
        SetFighterFloat("Speed", currentSpeed);
    }
}