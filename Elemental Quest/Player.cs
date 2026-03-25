using System;

public class Player : Character
{
    private int Gold;
    public Inventory Inventory { get; private set; }

    public Player(string name) : base(name)
    {
        Gold = 100;
        Inventory = new Inventory();
    }

    public int gold
    {
        get { return Gold; }
        set { Gold = value; }
    }
}
