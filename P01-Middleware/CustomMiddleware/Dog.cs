namespace P01_Middleware.CustomMiddleware;

public class Dog : IAnimal
{
    public string Speak()
    {
        return "Woof!";
    }
}