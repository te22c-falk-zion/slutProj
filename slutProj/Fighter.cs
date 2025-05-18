public class Fighter
{

    // Initialisering
    private string name;
    private float maxHP;
    private float HP;
    private float ATK;
    private float SPD;
    private float AV;

    public Fighter(string _name, float _maxHP, float _HP, float _ATK, float _SPD, float _AV)
    {
        name = _name;
        maxHP = _maxHP;
        HP = _HP;
        ATK = _ATK;
        SPD = _SPD;
        AV = _AV;
    }

    //metoder

    //Basic virtual atatck metod
    public virtual void Attack(Fighter target)
    {
        float finalDamage = GetFighterFloat("Attack");
        float currentHealth = target.GetFighterFloat("Health");
        target.SetFighterFloat("Health", currentHealth - finalDamage);
    }


    // Get float metod
    public float GetFighterFloat(string thing)
    {
        if (thing == "Health")
        {
            return HP;   
        }
        if (thing == "MaxHealth")
        {
            return maxHP;   
        }
        if (thing == "Attack")
        {
            return ATK;   
        }
        if (thing == "Speed")
        {
            return SPD;   
        }
        if (thing == "ActionValue")
        {
            return AV;   
        }
        else return 0;
    }

    //Set float metod.
    public void SetFighterFloat(string thing, float value)
    {
        switch (thing)
        {
            case "Health":
                HP = value;
                break;
            case "MaxHealth":
                maxHP = value;
                break;
            case "Attack":
                ATK = value;
                break;
            case "Speed":
                SPD = value;
                break;
            case "ActionValue":
                AV = value;
                break;
            default:
                break;
        }
    }

    //Get name metod.
    public string GetFighterName()
    {
        return name;
    }


}