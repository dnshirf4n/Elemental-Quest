using System;

public class Menu
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
