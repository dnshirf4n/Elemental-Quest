using System;

public class Character
{
    private string Name;
    private const int MaxHealth = 100;
    private int HealthPoint;
    private int Shield;
    protected int Damage;

    public Character(string name)
    {
        Name = name;
        HealthPoint = MaxHealth;
        Shield = 0;
        Damage = 20;
    }

    public string name
    {
        get { return Name; }
    }

    public int healthPoint
    {
        get { return HealthPoint; }
        set
        {
            if (value < 0) HealthPoint = 0;
            else if (value > MaxHealth) HealthPoint = MaxHealth;
            else HealthPoint = value;
        }
    }

    public int shield
    {
        get { return Shield; }
        set { Shield = value; }
    }

    public void Attack(Character target)
    {
        if (target.shield > 0)
        {
            target.shield--;
            Console.WriteLine($"{target.name} blocked the attack!");
        }
        else
        {
            target.healthPoint -= Damage;
            Console.WriteLine($"{name} dealt {Damage} damage to {target.name}!");
        }
    }
}
