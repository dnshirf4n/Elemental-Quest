using System;
using System.Collections.Generic;

public class Shop
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
