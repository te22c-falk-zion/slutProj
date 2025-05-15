



using System.Security.Cryptography.X509Certificates;

public class Buff : Item
{
    private float SPDbuff { get; set; }
    private float CRbuff { get; set; }
    private float CDbuff { get; set; }
    private float ATKbuff { get; set; }
    private float HPbuff { get; set; }

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

    public float GetBuff(string buffname)
    {
        if(buffname == "Speed")
        {
            return SPDbuff;
        }
        if(buffname == "CritRate")
        {
            return CRbuff;
        }        
        if(buffname == "CritDamage")
        {
            return CDbuff;
        }        
        if(buffname == "Attack")
        {
            return ATKbuff;
        }
        if(buffname == "health")
        {
            return HPbuff;
        }
        else return 0;
    }
}

