using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {

        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine=CuisineType.Mexican}
            };
        }



        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {

            return from r in _restaurants
                   where String.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(x => x.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.Single(r => r.Id == updatedRestaurant.Id);
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Cuisine = updatedRestaurant.Cuisine;
            restaurant.Location = updatedRestaurant.Location;

            return restaurant;
        }

        public int Commit()
        {
            return 0; 
        }
    }
}
