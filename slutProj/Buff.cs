



using System.Security.Cryptography.X509Certificates;

public class Buff : Item
{
    public float SPDbuff { get; set; }
    public float CRbuff { get; set; }
    public float CDbuff { get; set; }
    public float ATKbuff { get; set; }
    public float HPbuff { get; set; }

    public Buff(string Name, float spd, float cr, float cd, float atk, float hp, string bio) : base(Name, bio)
    {
        SPDbuff = spd;
        CRbuff = cr;
        CDbuff = cd;
        ATKbuff = atk;
        HPbuff = hp;
    }
    public override void Use()
    {
        Console.WriteLine($"{itemBio}");
        Console.ReadLine();
    }
}

