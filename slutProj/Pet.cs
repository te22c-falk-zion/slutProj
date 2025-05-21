using System.Runtime.InteropServices.Marshalling;

public class Pet 
{
    //Initialsiering
    private string name;
    private float percent;

    public Pet(string _name, float _percent)
    {
        name = _name;
        percent = _percent;
    }

    //metoder

    public virtual void PetTurn()
    {
        //Will be overriden in subclass.
    }

    public virtual void ChangeHp(Fighter target, float percent)
    {
        //Sparar herons hp innan något händer för att visa senare.
        float saveHP = target.GetFighterFloat("Health");

        //Applicerar hp heal/drain och sätter herons hp som det.
        float HPChange = target.GetFighterFloat("Health")/100 * percent;
        target.SetFighterFloat("Health", saveHP + HPChange);

        if (target.GetFighterFloat("Health") > target.GetFighterFloat("MaxHealth"))
        {
            target.SetFighterFloat("Health", target.GetFighterFloat("MaxHealth"));
        }

        //Skriver annorlunda text beroende på om ditt är under eller över det sparade saveHP tidigare i metoden.
        if(target.GetFighterFloat("Health") > saveHP)
        {
        Console.WriteLine($"{target.GetFighterName()} healed by {HPChange}.");
        Console.WriteLine($"{saveHP} --> {target.GetFighterFloat("Health")}");
        }
        if (target.GetFighterFloat("Health") < saveHP)
        {
            Console.WriteLine($"{target.GetFighterName()} lost {HPChange} health.");
            Console.WriteLine($"{saveHP} --> {target.GetFighterFloat("Health")}");
        }
    }

    public float GetPercent()
    {
        return percent;
    }
    public void SetPercent(float value)
    {
        percent = value;
    }
    public string GetPetName()
    {
        return name;
    }
}