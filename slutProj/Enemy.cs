public class Enemy : Fighter
{

    public override void Attack(Fighter target)
    {
        target.HP -= ATK;
    }

}