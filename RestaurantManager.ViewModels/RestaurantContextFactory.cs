﻿using System.Threading.Tasks;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public static class RestaurantContextFactory
    {
        private static RestaurantContext _restaurantContext;

        public static async Task<RestaurantContext> GetRestaurantContextAsync()
        {
            if (_restaurantContext != null)
            {
                return _restaurantContext;
            }

            _restaurantContext = new RestaurantContext();
            await _restaurantContext.InitializeContextAsync();

            return _restaurantContext;
        }
    }
}