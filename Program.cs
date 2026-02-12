using game;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.Clear();
        Console.WriteLine("Starting game!");
        Game game = new Game();
        game.init();
        game.Run();
    }   
}
