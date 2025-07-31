//Annette Hawks
//Due 7/23/2025
//Mad Libs 2


class Program
{
    static void Main()
    {
        //Main Code
        //Build the dictionary frame
        //args — had to change to user prompt for choices so that I could see the printed story
        Console.WriteLine("Enter 1 for Story 1 or 2 for Story 2:");
        string input = Console.ReadLine();
        string filename = "";

        if (input == "1") filename = "story1.txt";
        else if (input == "2") filename = "story2.txt";
        else
        {
            Console.WriteLine("Try again. Closing.");
            return;
        }

        //for each loops
        //pull out words from the story as strings to evaluate and determine where they go
        //(like last mad libs). Splitting the lines into words and checking for ::

        Dictionary<string, List<string>> categoryWords = BuildCatDictionary(filename);

        //use key and values to replace the words
        // make sure there are no duplicate words
        // build a random word puller (like a random number generator)
        string newStory = NewWords(filename, categoryWords);

        // display the story before saving it to a new file.
        Console.WriteLine("\n--- New Story ---\n");
        Console.WriteLine(newStory);

        string outputFilename = $"NewStory.{filename}";
        File.WriteAllText(outputFilename, newStory);

        Console.WriteLine($"\nStory saved as {outputFilename}");
    }

    //Method 1: BuildCatDictionary
    static Dictionary<string, List<string>> BuildCatDictionary(string filename)
    {
        Dictionary<string, List<string>> catDict = new();

        foreach (string line in File.ReadLines(filename))
        {
            string[] words = line.Split(' ');
            foreach (string word in words)
            {
                if (word.Contains("::"))
                {
                    string[] parts = word.Split("::");
                    if (parts.Length != 2) continue;
                    string actualWord = parts[0];
                    string category = parts[1];

                    if (!catDict.ContainsKey(category))
                        catDict[category] = new List<string>();

                    if (!catDict[category].Contains(actualWord))
                        catDict[category].Add(actualWord);
                }
            }
        }

        return catDict;
    }

    //Method 2: NewWords
    static string NewWords(string filename, Dictionary<string, List<string>> catDict)
    {
        Random rng = new Random();
        string[] lines = File.ReadAllLines(filename);
        List<string> newLines = new();

        foreach (string line in lines)
        {
            string[] words = line.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains("::"))
                {
                    string[] parts = words[i].Split("::");
                    if (parts.Length != 2) continue;
                    string category = parts[1];

                    if (catDict.ContainsKey(category) && catDict[category].Count > 0)
                    {
                        List<string> options = catDict[category];
                        string replacement = options[rng.Next(options.Count)];
                        words[i] = replacement;
                    }
                }
            }
            newLines.Add(string.Join(" ", words));
        }

        return string.Join("\n", newLines);
    }
}
