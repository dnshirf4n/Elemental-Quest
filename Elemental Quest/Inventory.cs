using System;

public class Inventory
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
