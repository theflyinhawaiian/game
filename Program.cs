using System;
using game;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.Clear();
        Console.WriteLine("Starting game!");
        Manager GameManager = new Manager();
        GameManager.StartGame();
        GameManager.Run();
    }   
}
