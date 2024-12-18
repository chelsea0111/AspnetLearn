using System.Text;

namespace P01_Middleware.CustomMiddleware;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendLineWithTimestamp(this StringBuilder sb, string msg)
    {
        return sb.AppendLine($"[{DateTime.Now}] {msg}");
    }
}