public class Fighter
{
    public string Name;
    public float HP;
    public float ATK;
    public float SPD;
    public float AV;


    public virtual void Attack(Fighter target)
    {
        target.HP -= ATK;
    }
    
    
}