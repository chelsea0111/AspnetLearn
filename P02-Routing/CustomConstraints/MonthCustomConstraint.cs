using System.Text.RegularExpressions;

namespace P02_Routing.CustomConstraints;

public class MonthCustomConstraint : IRouteConstraint
{
    // sales-report/2020/apr
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        // check whether the value exists
        if (!values.ContainsKey(routeKey)) // month
        {
            return false;
        }

        Regex regex = new Regex("^(apr|jul|oct|jan)$");
        string? monthValue = Convert.ToString(values[routeKey]);
        if (regex.IsMatch(monthValue))
        {
            return true;
        }

        return false;
    }
}