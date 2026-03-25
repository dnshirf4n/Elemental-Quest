using System;

public class Game
{
    public static void Start()
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
