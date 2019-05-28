using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSB100AzureApp1.UserProfileServiceReference;

namespace TSB100AzureApp1.Logic
{
    public class UserStatistics
    {
        public Dictionary<string, int> GetUserCityStats(IEnumerable<User> users)
        {
            var cities = new HashSet<string>(users.Select(user => user.City ?? "empty"));
            var userCityStats = new Dictionary<string, int>();

            foreach (var city in cities)
            {
                // Bygg upp linq-uttrycket
                var usersInCity = users.Where(user => (user.City ?? "empty") == city);

                // Kör Linq-uttrycket
                var count = usersInCity.Count();

                // Lägg till resultatet
                if (count > 0)
                {
                    userCityStats.Add(city, count);
                }
            }
            return userCityStats;
        }
    }
}