﻿using OdeToFood.Core;
using System.Collections.Generic;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {

        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);

        Restaurant Add(Restaurant newRestaurant);


        int Commit();
        int GetCountOfRestaurants();
    }
}
