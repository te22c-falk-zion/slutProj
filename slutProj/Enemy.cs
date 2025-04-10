public class Enemy : Fighter
{
    public float level;
    public override void Attack(Fighter target)
    {
        target.HP -= ATK;
    }
    public void LevelUp(int level)
    {
        HP = HP*level;
        ATK = ATK*level;
        SPD += level/10 * 6;
    }
}