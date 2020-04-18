using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IConfiguration config;
        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(
            IConfiguration config,
            IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
            this.config = config;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetAll();
        }
    }
}