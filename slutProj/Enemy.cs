public class Enemy : Fighter
{
    private float level;
    public override void Attack(Fighter target)
    {
        target.HP -= ATK * (Random.Shared.Next(1000,1500)/100);
    }
    public void LevelUp(float stage)
    {
        level += stage/2;
        HP += HP*level;
        ATK += ATK*level;
        SPD += level/10 * 6;
    }
}