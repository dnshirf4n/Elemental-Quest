using System;

public class Enemy : Character
{
    public Enemy(string name, int hp, int damage) : base(name)
    {
        healthPoint = hp;
        Damage = damage;
    }
}