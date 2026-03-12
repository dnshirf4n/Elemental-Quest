
using System.Globalization;
using System.Numerics;
using System.Collections.Generic;


class Character
{
	private string Name;
	private int Level;
	private const int MaxHealth = 100;
	private int HealthPoint;
	private int Shield;
	private int Damage;
	private string Element;
  
	public Character(string name) {
		Name = name;
		Level = 1;
		HealthPoint = MaxHealth;
		Shield = 0;
		Damage = 20;
		Element = "";

	}

	public string name
	{
		get {  return Name; }
	}
	public int maxHealth
	{
		get { return MaxHealth; }
	}
	public int healthPoint
	{
		get { return HealthPoint; }
		set
		{
			if (value < 0) HealthPoint = 0;
			else if(value>MaxHealth) HealthPoint = MaxHealth;
			else HealthPoint = value;
		}
	}

	public int shield
	{
		get { return Shield; }
		set { Shield = value; }
	}

}

class Player : Character
{
	private int Gold;
	public Inventory Inventory { get; private set; }
	public Player(string name) : base(name) // calls Character constructor
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

class Menu
{
	public static void DisplayMenu(Player player)
	{
		Console.Clear();
		Console.WriteLine("=== MAIN MENU ===");
		Console.WriteLine("1. Choose Level");
		Console.WriteLine("2. Open Shop");
		Console.WriteLine("3. Inventory");
		Console.WriteLine("0. Exit");
		Console.Write("Select an option: ");

		string input = Console.ReadLine();

		switch (input)
		{
			case "1":
				ChooseLevel();
				break;

			case "2":
				Shop.OpenShop(player);
				break;

			case "3":
				player.Inventory.ShowInventory();
				break;

			case "0":
				Console.WriteLine("Exiting game...");
				break;

			default:
				Console.WriteLine("Invalid option. Press any key to try again.");
				Console.ReadKey();
				break;
		}
	
	}

	public static void ChooseLevel()
	{
		Console.Clear();
		Console.WriteLine("=== LEVEL SELECTION ===");
		Console.WriteLine("Level 1");
		Console.WriteLine("Level 2");
		Console.WriteLine("Level 3");
		Console.WriteLine("\nPress any key to return to main menu...");
		Console.ReadKey();
	}

	
}

class Shop
{
	public static List<Potion> shopPotions;
	static Shop()
	{
		shopPotions = new List<Potion>();

		// Add default shop potions
		shopPotions.Add(new Potion("Small Health", "Heal", "+30 HP", 30, 30));
		shopPotions.Add(new Potion("Large Health", "Heal", "+65 HP ", 65, 50));
		shopPotions.Add(new Potion("Shield Potion", "Shield", "Blocks 2 hits", 2, 40));
	}
	public static void OpenShop(Player player)
	{
		Console.Clear();
		Console.WriteLine("=== Potion Shop ===");
		Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-15} {4,-10}", "No.", "Potion Name", "Type", "Effect", "Price");
		Console.WriteLine(new string('-', 55));
		for (int i = 0; i < shopPotions.Count; i++)
		{
			Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-15} {4,-10}", i + 1, shopPotions[i].name, shopPotions[i].type, shopPotions[i].description, shopPotions[i].effectValue, shopPotions[i].price);
		}
		Console.WriteLine(new string('-', 55));
		Console.Write($"Choose which potion to buy (1 - {shopPotions.Count})/(0 - To exit) : ");
		string input = Console.ReadLine();
		Potion selectedPotion;
		switch (input) {
			case "1":
				selectedPotion = shopPotions[0];
				BuyPotion(selectedPotion, player); 
				break;

			case "2":
			    selectedPotion = shopPotions[1];
				BuyPotion(selectedPotion, player);
				break;

			case "3":
				selectedPotion = shopPotions[2];
				BuyPotion(selectedPotion, player);
				break;

			case "0":
				Menu.DisplayMenu(player);
				break;

			default:
				Console.WriteLine("Invalid choice.");
				Console.ReadKey();
				break;
		}
		
	}

	public static void BuyPotion(Potion potion, Player player)
	{
		if (player.gold >= potion.price)
		{
			player.Inventory.AddToInventory(potion);
			player.gold = player.gold-potion.price;
			Console.ReadKey();
		}
		else
		{
			Console.WriteLine("Insufficient gold to buy this potion!");
			Console.ReadKey();
			
		}
		OpenShop(player);
	}

}

class Potion
{
	private string Name;
	private string Type;
	private string Description;
	private int EffectValue;
	private int Price;
	

	public string name
	{
		get { return Name; }
	}

	public string type
	{
		get { return Type; }
	}

	public string description
	{
		get { return Description; }
	}
	public int effectValue
	{
		get { return EffectValue; }
	}

	public int price
	{
		get { return Price; }
	}

	public Potion(string name, string type, string description, int effectValue, int price)
	{
		Name = name;
		Type = type;
		Description = description;
		EffectValue = effectValue;
		Price = price;
	}
	public void Use(Player player)
	{
		if (Type == "Heal")
		{
			player.healthPoint += EffectValue;
			if (player.healthPoint < player.maxHealth) {
				if (name == "Small")
					player.healthPoint = player.healthPoint += 30;

				else 
					player.healthPoint = player.healthPoint += 65;

				Console.WriteLine($"Healed {EffectValue} HP!"); }
			
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
	public List<Potion> Potions { get; set; }

	public Inventory()
	{
		Potions = new List<Potion>(); // initialize empty list
	}

	// Add potion to inventory
	public void AddToInventory(Potion potion)
	{
		Potions.Add(potion);
		Console.WriteLine($"{potion.name} potion added to inventory!");
	}

	// Show all potions
	public void ShowInventory()
	{
		Console.Clear();
		Console.WriteLine("=== Inventory ===");
		Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-15}", "No.", "Potion Name", "Type", "Effect");
		Console.WriteLine(new string('-', 55));
		for (int i = 0; i < Potions.Count; i++)
		{
			Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-15}", i + 1, Potions[i].name, Potions[i].type, Potions[i].description, Potions[i].effectValue);
		}
	}
}

class Game
{
	static void Main()
	{
		Console.WriteLine("=================================");
		Console.WriteLine("        ELEMENTAL QUEST          ");
		Console.WriteLine("=================================");
		Console.WriteLine("      Master the Elements        ");
		Console.WriteLine();
		Console.Write("Enter Player Name: ");
		string name = Console.ReadLine();
		Player player1 = new Player(name);
		Menu.DisplayMenu(player1);
		
	}
}
