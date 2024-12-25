using Microsoft.AspNetCore.Mvc;

namespace P03_Controllers.Models;

public class Book
{
    [FromQuery]
    public int? BookId { get; set; }
    public string? Author { get; set; }

    public override string ToString()
    {
        return $"{nameof(BookId)}: {BookId}, {nameof(Author)}: {Author}";
    }
}