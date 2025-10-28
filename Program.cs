
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

        string[] missingLetters = new string[ranWord.Length];
       
        //Establishing missing letters
        for (int i = 0; i < ranWord.Length; i++)
        {
            missingLetters[i] = "_";
        }


        Console.WriteLine(ranWord);

        //Writes out underscores = to ranword length
        for (int l = 0; l < ranWord.Length; l++)
        {
            Console.WriteLine(missingLetters[l]);
        }
        


        
        while (wordFound == false && guessCounter < 7)
        {

            var letterFound = false;

            
            //Takes a letter from the player, converts it into a character
            Console.WriteLine("Guess a Letter: ");
            var input = Console.ReadLine();
            char character = char.Parse(input);

            

            for (int c = 0; c < ranWord.Length; c++)
            {
                if (character == ranWord[c])
                {
                    missingLetters[c] = ranWord[c].ToString();
                }
            }

            guessCounter++;
            for (int i = 0; i < ranWord.Length; i++)
            {
                Console.WriteLine(missingLetters[i]);
            }


        }
        

    }
}