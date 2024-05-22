using System;
using System.Threading;

abstract class Activity
{
    protected int durationInSeconds;
    protected string description;

    public abstract void PerformActivity();

    public void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        durationInSeconds = Convert.ToInt32(Console.ReadLine());
    }

    public virtual void DisplayStartMessage()
    {
        Console.WriteLine($"Starting activity: {description}");
        Console.WriteLine(description);
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(2000);
    }

    public virtual void DisplayEndMessage(string activityName)
    {
        Console.WriteLine($"Great job! You have completed the activity: {activityName}");
        Console.WriteLine($"Total time: {durationInSeconds} seconds");
        Thread.Sleep(2000);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        description = "This activity will help you relax as you walk through slow inhalation and exhalation. Clear your mind and focus on your breathing.";
    }

    public override void PerformActivity()
    {
        Console.WriteLine("Inhale...");
        Thread.Sleep(2000);
        Console.WriteLine("Exhale...");
        Thread.Sleep(2000);
        for (int i = 0; i < durationInSeconds / 4 - 1; i++)
        {
            Console.WriteLine("Inhale...");
            Thread.Sleep(2000);
            Console.WriteLine("Exhale...");
            Thread.Sleep(2000);
        }
    }
}

class ReflectionActivity : Activity
{
    private string[] reflectionPrompts = {
        "Think of a moment when you stood up for someone else.",
        "Think of a moment when you did something really challenging.",
        "Think of a moment when you helped someone in need.",
        "Think of a moment when you did something truly selfless."
    };

    public ReflectionActivity()
    {
        description = "This activity will help you reflect on moments in your life where you've demonstrated strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void PerformActivity()
    {
        Random rnd = new Random();
        foreach (string prompt in reflectionPrompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(2000);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Reflect on the question...");
                Thread.Sleep(2000);
            }
        }
    }
}

class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are the people you appreciate?",
        "What are your personal strengths?",
        "Who are the people you've helped this week?",
        "When have you felt the Holy Spirit this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a given area.";
    }

    public override void PerformActivity()
    {
        Random rnd = new Random();
        Console.WriteLine(listingPrompts[rnd.Next(listingPrompts.Length)]);
        Thread.Sleep(2000);
        Console.WriteLine("Start listing!");
        Thread.Sleep(2000);
    }
}

class MindfulnessProgram
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid selection. Please try again.");
                continue;
            }

            Activity currentActivity = null;

            switch (choice)
            {
                case 1:
                    currentActivity = new BreathingActivity();
                    break;
                case 2:
                    currentActivity = new ReflectionActivity();
                    break;
                case 3:
                    currentActivity = new ListingActivity();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    return;
            }

            currentActivity.SetDuration();
            currentActivity.DisplayStartMessage();
            currentActivity.PerformActivity();
            currentActivity.DisplayEndMessage(currentActivity.GetType().Name);
        }
    }
}
