namespace P08_Services;
using P08_ServiceContracts;
public class CitiesService: ICitiesService
{
    private List<string> _cities;

    public CitiesService()
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