﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
       readonly List<Restaurant> restaurants;
        private object restaurant;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()

            {
                new Restaurant {Id = 1, Name = "Pizza", Location = "Utrecht", Cuisine=CuisineType.Mexican},
                new Restaurant {Id = 2, Name = "Himalayan", Location = "Amsterdam", Cuisine=CuisineType.Nepali},
                new Restaurant {Id = 3, Name = "Tandoor", Location = "Rottardam", Cuisine=CuisineType.Indian},
                new Restaurant {Id = 4, Name = "Bonjur", Location = "Amsterdam", Cuisine=CuisineType.None},
                new Restaurant {Id = 5, Name = "ABC", Location = "Den Haag", Cuisine=CuisineType.Dutch}
            };
        }

        public Restaurant GetById (int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
           
        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant!=null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}