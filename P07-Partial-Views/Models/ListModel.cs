namespace P07_Partial_Views.Models;

public class ListModel
{
    public string ListTitle { get; set; }

    public List<string> ListItems { get; set; } = new List<string>()
    {
        "Rome",
        "London",
        "Beijing",
        "Tokyo",
        "Thailand"
    };
}