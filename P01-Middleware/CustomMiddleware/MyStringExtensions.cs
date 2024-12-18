namespace P01_Middleware.CustomMiddleware;

public static class MyStringExtensions
{
    public static bool IsNumeric(this string input)
    {
        return int.TryParse(input, out _);
    }
}