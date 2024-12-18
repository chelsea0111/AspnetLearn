namespace P01_Middleware.CustomMiddleware;

public static class MyListExtensions
{
    public static int CountEvenNumbers(this List<int> list)
    {
        return list.Count((n) => n % 2 == 0);
    }
}