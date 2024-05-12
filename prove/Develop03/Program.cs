using System;
using System.Collections.Generic;

namespace ScripturePassageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the class representing the Scripture passage
            var scripture = new ScripturePassage("John 3:16", "For God so loved the world...");

            // Hide random words in the text
            scripture.HideRandomWords();

            // Display the full passage (reference and text)
            Console.WriteLine(scripture.GetFullPassage());

            // Wait for the user to press Enter or type "quit"
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            var userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                return;
            }

            // Continue hiding more words until all are hidden
            while (!scripture.AllWordsHidden)
            {
                scripture.HideRandomWords();
                Console.Clear();
                Console.WriteLine(scripture.GetFullPassage());
                Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "quit")
                {
                    return;
                }
            }
        }
    }

    class ScripturePassage
    {
        private readonly string reference;
        private readonly string text;
        private List<string> words;
        private HashSet<int> hiddenWordIndices;

        public bool AllWordsHidden => hiddenWordIndices.Count == words.Count;

        public ScripturePassage(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            words = new List<string>(text.Split(' '));
            hiddenWordIndices = new HashSet<int>();
        }

        public void HideRandomWords()
        {
            var random = new Random();
            var wordIndex = random.Next(words.Count);
            while (hiddenWordIndices.Contains(wordIndex))
            {
                wordIndex = random.Next(words.Count);
            }
            hiddenWordIndices.Add(wordIndex);
        }

        public string GetFullPassage()
        {
            var visibleText = new List<string>(words);
            foreach (var index in hiddenWordIndices)
            {
                visibleText[index] = new string('*', words[index].Length);
            }
            return $"{reference}: {string.Join(" ", visibleText)}";
        }
    }
}
