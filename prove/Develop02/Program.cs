using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnhancedDiary
{
    class DiaryEntry
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public List<string> Categories { get; set; } // New property for categories
    }

    class Program
    {
        static List<DiaryEntry> diaryEntries = new List<DiaryEntry>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Diary Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Show all entries");
                Console.WriteLine("3. Save diary to a CSV file");
                Console.WriteLine("4. Load diary from a CSV file");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry();
                        break;
                    case "2":
                        ShowAllEntries();
                        break;
                    case "3":
                        SaveDiaryToCsv();
                        break;
                    case "4":
                        LoadDiaryFromCsv();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void WriteNewEntry()
        {
            Console.Write("Enter your message: ");
            string message = Console.ReadLine();
            Console.Write("Enter categories (comma-separated): ");
            string categoriesInput = Console.ReadLine();
            List<string> categories = categoriesInput.Split(',').Select(c => c.Trim()).ToList();

            DiaryEntry entry = new DiaryEntry
            {
                Message = message,
                Date = DateTime.Now,
                Categories = categories
            };
            diaryEntries.Add(entry);
            Console.WriteLine("Entry added successfully!");
        }

        static void ShowAllEntries()
        {
            Console.WriteLine("Diary Entries:");
            foreach (var entry in diaryEntries)
            {
                Console.WriteLine($"{entry.Date}: {entry.Message} ({string.Join(", ", entry.Categories)})");
            }
        }

        static void SaveDiaryToCsv()
        {
            Console.Write("Enter a filename to save the diary (without extension): ");
            string filename = Console.ReadLine() + ".csv";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in diaryEntries)
                {
                    writer.WriteLine($"{entry.Date},{entry.Message},{string.Join("|", entry.Categories)}");
                }
            }
            Console.WriteLine($"Diary saved to {filename}.");
        }

        static void LoadDiaryFromCsv()
        {
            Console.Write("Enter the filename to load the diary from (with .csv extension): ");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                diaryEntries.Clear();
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');
                        if (parts.Length >= 2)
                        {
                            DateTime date;
                            if (DateTime.TryParse(parts[0], out date))
                            {
                                DiaryEntry entry = new DiaryEntry
                                {
                                    Date = date,
                                    Message = parts[1],
                                    Categories = parts.Length > 2 ? parts[2].Split('|').ToList() : new List<string>()
                                };
                                diaryEntries.Add(entry);
                            }
                        }
                    }
                }
                Console.WriteLine($"Diary loaded from {filename}.");
            }
            else
            {
                Console.WriteLine($"File {filename} does not exist.");
            }
        }
    }
}
