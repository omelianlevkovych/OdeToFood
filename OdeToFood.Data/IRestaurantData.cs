using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant
                    {Id = 1, Name = "Puzata hata", Location = "University 1", Cuisine = CuisineType.Ukrainian},
                new Restaurant
                    {Id = 1, Name = "Japanese sushi", Location = "Japanese 9", Cuisine = CuisineType.Japanese},
                new Restaurant
                    {Id = 1, Name = "Celentano", Location = "Italian square 3", Cuisine = CuisineType.Italian}
            };

        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
