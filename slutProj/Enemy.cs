public class Enemy 
{
    public string Name;

    public float HP;
    public float ATK;
    public float SPD;
    public float AV;

    public void Attack(Hero target)
    {
        target.HP -= ATK;
    }
    public void SetAV(Enemy target)
    {
        target.AV = 10000/target.SPD;
    }
    
}