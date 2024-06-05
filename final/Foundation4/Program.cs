using System;

namespace GymTracker
{
    // Base class for exercise activities
    public abstract class Exercise
    {
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }

        public Exercise(DateTime date, int durationMinutes)
        {
            Date = date;
            DurationMinutes = durationMinutes;
        }

        public abstract double CalculateDistance();
        public abstract double CalculateSpeed();
        public double CalculatePace() => DurationMinutes / CalculateDistance();
    }

    // Running activity
    public class Running : Exercise
    {
        public double DistanceMiles { get; set; }

        public Running(DateTime date, int durationMinutes, double distanceMiles)
            : base(date, durationMinutes)
        {
            DistanceMiles = distanceMiles;
        }

        public override double CalculateDistance() => DistanceMiles * 1.60934; // Convert miles to kilometers
        public override double CalculateSpeed() => CalculateDistance() / (DurationMinutes / 60.0); // km/h
    }

    // Cycling activity
    public class Cycling : Exercise
    {
        public double SpeedKmPerHour { get; set; }

        public Cycling(DateTime date, int durationMinutes, double speedKmPerHour)
            : base(date, durationMinutes)
        {
            SpeedKmPerHour = speedKmPerHour;
        }

        public override double CalculateDistance() => SpeedKmPerHour * (DurationMinutes / 60.0);
        public override double CalculateSpeed() => SpeedKmPerHour;
    }

    // Swimming activity
    public class Swimming : Exercise
    {
        public int Laps { get; set; }

        public Swimming(DateTime date, int durationMinutes, int laps)
            : base(date, durationMinutes)
        {
            Laps = laps;
        }

        public override double CalculateDistance() => Laps * 50.0; // Each lap is 50 meters
        public override double CalculateSpeed() => CalculateDistance() / (DurationMinutes / 60.0); // km/h
    }

    class Program
    {
        static void Main(string[] args)
        {
            var runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
            var cyclingActivity = new Cycling(new DateTime(2022, 11, 3), 30, 9.7);
            var swimmingActivity = new Swimming(new DateTime(2022, 11, 3), 30, 10);

            Console.WriteLine($"03 Nov 2022 Running (30 min) - Distance {runningActivity.CalculateDistance():F1} km, Speed {runningActivity.CalculateSpeed():F1} km/h, Pace: {runningActivity.CalculatePace():F2} min/km");
            Console.WriteLine($"03 Nov 2022 Cycling (30 min) - Distance {cyclingActivity.CalculateDistance():F1} km, Speed {cyclingActivity.CalculateSpeed():F1} km/h, Pace: {cyclingActivity.CalculatePace():F2} min/km");
            Console.WriteLine($"03 Nov 2022 Swimming (30 min) - Distance {swimmingActivity.CalculateDistance():F1} m, Speed {swimmingActivity.CalculateSpeed():F1} km/h, Pace: {swimmingActivity.CalculatePace():F2} min/km");
        }
    }
}
