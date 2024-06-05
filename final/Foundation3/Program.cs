using System;

class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Location { get; set; }

    public Event(string title, string description, DateTime date, TimeSpan time, string location)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Location = location;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nLocation: {Location}";
    }

    public virtual string GetBriefDescription()
    {
        return $"{GetType().Name}: {Title} ({Date.ToShortDateString()})";
    }
}

class Conference : Event
{
    public string SpeakerName { get; set; }
    public int SpeakerCapacity { get; set; }

    public Conference(string title, string description, DateTime date, TimeSpan time, string location,
                    string speakerName, int speakerCapacity)
        : base(title, description, date, time, location)
    {
        SpeakerName = speakerName;
        SpeakerCapacity = speakerCapacity;
    }

    public override string GetStandardDetails()
    {
        return base.GetStandardDetails() + $"\nSpeaker: {SpeakerName}, Capacity: {SpeakerCapacity}";
    }
}

class Reception : Event
{
    public string ConfirmationEmail { get; set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, string location,
                    string confirmationEmail)
        : base(title, description, date, time, location)
    {
        ConfirmationEmail = confirmationEmail;
    }

    public override string GetStandardDetails()
    {
        return base.GetStandardDetails() + $"\nConfirmation Email: {ConfirmationEmail}";
    }
}

class OutdoorMeeting : Event
{
    public string WeatherForecast { get; set; }

    public OutdoorMeeting(string title, string description, DateTime date, TimeSpan time, string location,
                        string weatherForecast)
        : base(title, description, date, time, location)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetStandardDetails()
    {
        return base.GetStandardDetails() + $"\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main()
    {
        var conference = new Conference("Tech Conference", "Cutting-edge tech talks",
                                        new DateTime(2024, 6, 15), new TimeSpan(10, 0, 0),
                                        "123 Main St, Example City", "John Doe", 100);

        var reception = new Reception("Gala Reception", "Elegant evening gathering",
                                    new DateTime(2024, 6, 20), new TimeSpan(18, 30, 0),
                                    "456 Elm St, Example City", "email@example.com");

        var outdoorMeeting = new OutdoorMeeting("Park Picnic", "Casual outdoor meetup",
                                                new DateTime(2024, 6, 25), new TimeSpan(12, 0, 0),
                                                "789 Oak St, Example City", "Sunny");

        Console.WriteLine(conference.GetStandardDetails());
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(outdoorMeeting.GetStandardDetails());
    }
}
