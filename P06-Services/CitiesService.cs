namespace P06_Services;

public class CitiesService
{
    private List<string> _cities;

    public CitiesService(List<string> cities)
    {
        _cities = new List<string>()
        {
            "London",
            "Paris",
            "New York",
            "Tokyo",
            "Rome"
        };
    }

    public List<string> GetCities() => _cities;
}