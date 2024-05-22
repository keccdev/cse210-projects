using System;
using System.Threading;

abstract class Activity
{
    protected int durationInSeconds;
    protected string description;

    public abstract void PerformActivity();

    public void SetDuration()
    {
        Console.Write("Ingrese la duración de la actividad en segundos: ");
        durationInSeconds = Convert.ToInt32(Console.ReadLine());
    }

    public virtual void DisplayStartMessage()
    {
        Console.WriteLine($"Comenzando la actividad: {description}");
        Console.WriteLine(description);
        Console.WriteLine("Prepárate para empezar...");
        Thread.Sleep(2000);
    }

    public virtual void DisplayEndMessage(string activityName)
    {
        Console.WriteLine($"¡Buen trabajo! Has completado la actividad: {activityName}");
        Console.WriteLine($"Tiempo total: {durationInSeconds} segundos");
        Thread.Sleep(2000);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        description = "Esta actividad te ayudará a relajarte al caminar a través de la inhalación y exhalación lentamente. Despeja tu mente y concéntrate en tu respiración.";
    }

    public override void PerformActivity()
    {
        Console.WriteLine("Inhala...");
        Thread.Sleep(2000);
        Console.WriteLine("Exhala...");
        Thread.Sleep(2000);
        for (int i = 0; i < durationInSeconds / 4 - 1; i++)
        {
            Console.WriteLine("Inhala...");
            Thread.Sleep(2000);
            Console.WriteLine("Exhala...");
            Thread.Sleep(2000);
        }
    }
}

class ReflectionActivity : Activity
{
    private string[] reflectionPrompts = {
        "Piensa en un momento en el que defendiste a otra persona.",
        "Piensa en un momento en el que hiciste algo realmente difícil.",
        "Piensa en un momento en el que hayas ayudado a alguien que lo necesitaba.",
        "Piensa en un momento en el que hiciste algo verdaderamente desinteresado."
    };

    public ReflectionActivity()
    {
        description = "Esta actividad te ayudará a reflexionar sobre los momentos de tu vida en los que has demostrado fortaleza y resiliencia. Esto te ayudará a reconocer el poder que tienes y cómo puedes usarlo en otros aspectos de tu vida.";
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
                Console.WriteLine("Reflexiona sobre la pregunta...");
                Thread.Sleep(2000);
            }
        }
    }
}

class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "¿Quiénes son las personas que aprecias?",
        "¿Cuáles son tus fortalezas personales?",
        "¿Quiénes son las personas a las que has ayudado esta semana?",
        "¿Cuándo has sentido el Espíritu Santo este mes?",
        "¿Quiénes son algunos de tus héroes personales?"
    };

    public ListingActivity()
    {
        description = "Esta actividad te ayudará a reflexionar sobre las cosas buenas de tu vida al hacer que hagas una lista de tantas cosas como puedas en un área determinada.";
    }

    public override void PerformActivity()
    {
        Random rnd = new Random();
        Console.WriteLine(listingPrompts[rnd.Next(listingPrompts.Length)]);
        Thread.Sleep(2000);
        Console.WriteLine("¡Comienza a enumerar!");
        Thread.Sleep(2000);
    }
}

class MindfulnessProgram
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Selecciona una actividad:");
            Console.WriteLine("1. Actividad Respiratoria");
            Console.WriteLine("2. Actividad de Reflexión");
            Console.WriteLine("3. Actividad de Enumeración");
            Console.WriteLine("4. Salir");

            Console.Write("Ingrese su elección: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Selección no válida. Por favor, intente de nuevo.");
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
                    Console.WriteLine("¡Hasta luego!");
                    return;
            }

            currentActivity.SetDuration();
            currentActivity.DisplayStartMessage();
            currentActivity.PerformActivity();
            currentActivity.DisplayEndMessage(currentActivity.GetType().Name);
        }
    }
}
