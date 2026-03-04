using game;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.Clear();
        Console.WriteLine("Starting game!");
        GameManager gm = new GameManager(new Game());
        gm.init();
        gm.Run();
    }   
}
