namespace P08_Services;

using P08_ServiceContracts;

public class CitiesService : ICitiesService
{
    private List<string> _cities;
    private Guid _serviceInstanceId;

    public CitiesService()
    {
        _serviceInstanceId = Guid.NewGuid();
        _cities = new List<string>()
        {
            "London",
            "Paris",
            "New York",
            "Tokyo",
            "Rome"
        };
    }

    public Guid ServiceInstanceId => _serviceInstanceId;

    public List<string> GetCities() => _cities;
}