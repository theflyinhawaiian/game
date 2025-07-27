
public class Program
{
    public static void Main(string[] args)
    {
        string[] words = new[]
        {
            "the","of","and","a","to","in","is","you","that","it",
            "he","for","was","on","are","as","with","his","they","at",
            "be","this","from","I","have","or","by","one","had","not",
            "but","what","all","were","when","we","there","can","an","your",
            "which","their","said","if","do","will","each","about","how","up",
            "out","them","then","she","many","some","so","these","would","other",
            "into","has","more","her","two","like","him","see","time","could",
            "no","make","than","first","been","its","who","now","people","my",
            "made","over","did","down","only","way","find","use","may","water",
            "long","little","very","after","words","called","just","where","most","know",
            "get","through","back","much","go","good","new","write","our","me",
            "man","too","any","day","same","right","look","think","also","around",
            "another","came","come","work","three","must","because","does","part","even",
            "place","well","such","here","take","why","help","put","different","off",
            "again","old","great","tell","men","say","small","every","found","still",
            "between","home","big","give","air","line","set","own","under","read",
            "last","never","us","left","end","along","while","might","next","sound",
            "below","saw","something","thought","both","few","those","always","show","large",
            "often","together","asked","house","going","want","school","important","until","form", "balls","cum"
            
        };
        var wordFound = false;

        int guessCounter = 0;

        var random = new Random();
        var ranWordNum = random.Next(words.Length) + 1;
        var ranWord = words[ranWordNum];

        string missLetters = "";

        for (int i = 0; i < ranWord.Length; i++)
        {
            missLetters = missLetters + "_";
        }

        Console.WriteLine(missLetters);


        Console.WriteLine(ranWord);
        while (wordFound == false && guessCounter < 7)
        {
            var letterFound = false;

            Console.WriteLine("Guess a Letter: ");

            var input = Console.ReadLine();

            
            char character = char.Parse(input);
            foreach (char c in ranWord)
            {
                if (character == c)
                {
                    letterFound = true;
                }
            }
            guessCounter++;
            Console.WriteLine(letterFound);

            
            
            
        }
        










    }
}