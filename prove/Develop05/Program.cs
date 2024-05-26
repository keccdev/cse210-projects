using System;
using System.Collections.Generic;

public abstract class Activity
{
    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public bool Completed { get; protected set; }

    public abstract void Complete();
}

public class SimpleGoal : Activity
{
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        Completed = false;
    }

    public override void Complete()
    {
        Completed = true;
    }
}

public class Menu
{
    private List<Activity> activities = new List<Activity>();

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("== Main Menu ==");
            Console.WriteLine("1. Add New Event");
            Console.WriteLine("2. View Events");
            Console.WriteLine("3. Mark Event as Completed");
            Console.WriteLine("4. Total Score");
            Console.WriteLine("5. Exit");
            Console.WriteLine("=================");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddNewEvent();
                    break;
                case "2":
                    ViewEvents();
                    break;
                case "3":
                    MarkEventCompleted();
                    break;
                case "4":
                    ShowTotalScore();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please select again.");
                    break;
            }
        }
    }

    private void AddNewEvent()
    {
        Console.WriteLine("Enter the name of the event:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the points for this event:");
        int points = int.Parse(Console.ReadLine());

        activities.Add(new SimpleGoal(name, points));
        Console.WriteLine("Event added successfully.");
    }

    private void ViewEvents()
    {
        Console.WriteLine("== Available Events ==");
        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name} - Points: {activities[i].Points} - {(activities[i].Completed ? "Completed" : "Pending")}");
        }
        Console.WriteLine("======================");
    }

    private void MarkEventCompleted()
    {
        Console.WriteLine("Enter the number of the event you want to mark as completed:");
        int choice = int.Parse(Console.ReadLine());
        if (choice >= 1 && choice <= activities.Count)
        {
            activities[choice - 1].Complete();
            Console.WriteLine("Event marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid event number.");
        }
    }

    private void ShowTotalScore()
    {
        Console.WriteLine("== Total Score ==");
        int totalScore = 0;
        int completedCount = 0;
        foreach (var activity in activities)
        {
            if (activity.Completed)
            {
                Console.WriteLine($"{activity.Name} - Points: {activity.Points}");
                totalScore += activity.Points;
                completedCount++;
            }
        }
        Console.WriteLine($"Completed Events: {completedCount}");
        Console.WriteLine($"Total Score: {totalScore} points");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}
