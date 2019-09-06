using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);

    }
    public class InMemoryRestaurantData : IRestaurantData
    {
       readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()

            {
                new Restaurant {Id = 1, Name = "Pizza", Location = "Utrecht", Cuisine=CuisineType.Mexican},
                new Restaurant {Id = 2, Name = "Himalayan", Location = "Amsterdam", Cuisine=CuisineType.Nepali},
                new Restaurant {Id = 3, Name = "Tandoor", Location = "Rottardam", Cuisine=CuisineType.Indian},
                new Restaurant {Id = 4, Name = "Bonjur", Location = "Amsterdam", Cuisine=CuisineType.None}


            };
        }

        public Restaurant GetById (int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
            
        /*
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name                 
                   select r;
        }
        */
        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }
    }
}
