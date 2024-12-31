namespace P08_Services;

public class CitiesServices
{
    private List<string> _cities;

    public CitiesServices(List<string> cities)
    {
        _cities = cities = new List<string>()
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