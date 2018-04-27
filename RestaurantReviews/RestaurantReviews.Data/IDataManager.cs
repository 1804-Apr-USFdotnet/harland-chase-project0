using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Model;

namespace RestaurantReviews.Data
{
    public interface IDataManager
    {
        // CRUD methods
        // Restaurants
        Restaurant[] GetRestaurants();
        Restaurant GetRestaurant(int id);
        bool AddRestaurant(Restaurant restaurant);
        Restaurant UpdateRestaurant(int id, Restaurant newValues);
        bool RemoveRestaurant(int id);

        // Reviews
        Review[] GetReviews();
        Review GetReview(int id);
        bool AddReview(Review review);
        Review UpdateReview(int id, Review newValues);
        bool RemoveReview(int id);
    }
}
