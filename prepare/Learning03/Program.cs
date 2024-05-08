using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear instancias de fracciones
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        // Mostrar representaciones y valores
        Console.WriteLine($"Fracción 1: {f1.GetFractionString()} (Valor decimal: {f1.GetDecimalValue()})");
        Console.WriteLine($"Fracción 2: {f2.GetFractionString()} (Valor decimal: {f2.GetDecimalValue()})");
        Console.WriteLine($"Fracción 3: {f3.GetFractionString()} (Valor decimal: {f3.GetDecimalValue()})");
        Console.WriteLine($"Fracción 4: {f4.GetFractionString()} (Valor decimal: {f4.GetDecimalValue()})");
    }
}