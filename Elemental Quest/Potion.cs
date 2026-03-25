using System;

public class Potion
{
    private string Name;
    private string Type;
    private int EffectValue;
    private int Price;

    public Potion(string name, string type, int effectValue, int price)
    {
        Name = name;
        Type = type;
        EffectValue = effectValue;
        Price = price;
    }

    public string name => Name;
    public string type => Type;
    public int effectValue => EffectValue;
    public int price => Price;

    public void Use(Player player)
    {
        if (Type == "Heal")
        {
            player.healthPoint += EffectValue;
            Console.WriteLine($"Healed {EffectValue} HP!");
        }
        else if (Type == "Shield")
        {
            player.shield = EffectValue;
            Console.WriteLine($"Shield activated for {EffectValue} rounds!");
        }
    }
}
