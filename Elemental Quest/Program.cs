using System;
using System.Collections.Generic;

class Character
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

class Player : Character
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

class Enemy : Character
{
    public Enemy(string name, int hp, int damage) : base(name)
    {
        healthPoint = hp;
        Damage = damage;
    }
}

class Menu
{
    public static void DisplayMenu(Player player)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MAIN MENU ===");
            Console.WriteLine("1. Choose Level");
            Console.WriteLine("2. Open Shop");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("0. Exit");
            Console.Write("Select option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ChooseLevel(player);
                    break;

                case "2":
                    Shop.OpenShop(player);
                    break;

                case "3":
                    player.Inventory.ShowInventory();
                    Console.ReadKey();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static void ChooseLevel(Player player)
    {
        Console.Clear();
        Console.WriteLine("=== LEVEL SELECTION ===");
        Console.WriteLine("1. Level 1 (Goblin)");
        Console.WriteLine("2. Level 2 (Orc)");
        Console.WriteLine("3. Level 3 (Dragon)");
        Console.WriteLine("0. Back");

        Console.Write("Choose level: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":

                StartBattle(player, new Enemy("Goblin", 60, 10));
                break;

            case "2":
                StartBattle(player, new Enemy("Orc", 100, 20));
                break;

            case "3":
                StartBattle(player, new Enemy("Dragon", 150, 35));
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Invalid choice!");
                Console.ReadKey();
                break;
        }
    }

    public static void StartBattle(Player player, Enemy enemy)
    {
        Console.Clear();
        Console.WriteLine($"A wild {enemy.name} appeared!");

        while (player.healthPoint > 0 && enemy.healthPoint > 0)
        {
            Console.WriteLine($"\n{player.name} HP: {player.healthPoint}");
            Console.WriteLine($"{enemy.name} HP: {enemy.healthPoint}");

            Console.WriteLine("\n1. Attack");
            Console.WriteLine("2. Use Potion");
            Console.WriteLine("0. Run");

            Console.Write("Action: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.Attack(enemy);

                if (enemy.healthPoint > 0)
                {
                    enemy.Attack(player);
                }
            }
            else if (choice == "2")
            {
                player.Inventory.UsePotion(player);
            }
            else if (choice == "0")
            {
                Console.WriteLine("You ran away!");
                Console.ReadKey();
                return;
            }
        }

        if (player.healthPoint > 0)
        {
            Console.WriteLine($"\nYou defeated {enemy.name}!");
            player.gold += 50;
            Console.WriteLine("You earned 50 gold!");
        }
        else
        {
            Console.WriteLine("\nYou were defeated...");
        }

        Console.ReadKey();
    }
}

class Shop
{
    public static List<Potion> shopPotions;

    static Shop()
    {
        shopPotions = new List<Potion>()
        {
            new Potion("Small Health", "Heal", 30, 30),
            new Potion("Large Health", "Heal", 65, 50),
            new Potion("Shield Potion", "Shield", 2, 40)
        };
    }

    public static void OpenShop(Player player)
    {
        Console.Clear();
        Console.WriteLine("=== Potion Shop ===");

        for (int i = 0; i < shopPotions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {shopPotions[i].name} | {shopPotions[i].type} | Effect: {shopPotions[i].effectValue} | Price: {shopPotions[i].price}");
        }

        Console.WriteLine("0. Exit");
        Console.Write("Choose potion: ");

        string input = Console.ReadLine();

        if (input == "0") return;

        int choice;
        if (int.TryParse(input, out choice) && choice >= 1 && choice <= shopPotions.Count)
        {
            BuyPotion(shopPotions[choice - 1], player);
        }
    }

    public static void BuyPotion(Potion potion, Player player)
    {
        if (player.gold >= potion.price)
        {
            player.gold -= potion.price;
            player.Inventory.AddPotion(potion);
            Console.WriteLine($"{potion.name} added to inventory!");
        }
        else
        {
            Console.WriteLine("Not enough gold!");
        }

        Console.ReadKey();
    }
}

class Potion
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

class Inventory
{
    private List<Potion> potions;

    public Inventory()
    {
        potions = new List<Potion>();
    }

    public void AddPotion(Potion potion)
    {
        potions.Add(potion);
    }

    public void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("=== Inventory ===");

        if (potions.Count == 0)
        {
            Console.WriteLine("Inventory empty.");
            return;
        }

        for (int i = 0; i < potions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {potions[i].name} | {potions[i].type} | Effect: {potions[i].effectValue}");
        }
    }

    public void UsePotion(Player player)
    {
        ShowInventory();

        if (potions.Count == 0)
        {
            Console.ReadKey();
            return;
        }

        Console.Write("Choose potion: ");
        int choice;

        if (int.TryParse(Console.ReadLine(), out choice))
        {
            if (choice >= 1 && choice <= potions.Count)
            {
                potions[choice - 1].Use(player);
                potions.RemoveAt(choice - 1);
            }
        }

        Console.ReadKey();
    }
}

class Game
{
    static void Main()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("        ELEMENTAL QUEST          ");
        Console.WriteLine("=================================");

        Console.WriteLine("           __");
        Console.WriteLine("          / _)");
        Console.WriteLine("   .-^^^-/ /  ");
        Console.WriteLine(" __/       /   ");
        Console.WriteLine("<__.|_|-|_|    ");
        Console.WriteLine();
        Console.WriteLine("       A WILD DINOSAUR APPEARS!");
        Console.WriteLine("       Prepare for battle...");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        Console.Write("Enter Player Name: ");
        string name = Console.ReadLine();

        Player player = new Player(name);

        Menu.DisplayMenu(player);
    }
}