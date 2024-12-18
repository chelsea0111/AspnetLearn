namespace P01_Middleware.CustomMiddleware;

public interface IAnimal
{
    string Speak();
}

public static class AnimalExtensions
{
    // privide a default function of interface IAnimal
    public static void PrintDetails(this IAnimal animal)
    {
        Console.WriteLine($"Animal says: {animal.Speak()}");
    }
}