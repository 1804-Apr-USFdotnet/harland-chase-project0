using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Model;
using System.Data.Entity;

namespace RestaurantReviews.Data
{
    public interface IDataManager
    {
        // CRUD methods
        // Restaurants
        DbSet<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
        int AddRestaurant(Restaurant restaurant);
        Restaurant UpdateRestaurant(int id, string restname);
        bool RemoveRestaurant(int id);

        // Reviews
        DbSet<Review> GetReviews();
        Review GetReview(int id);
        int AddReview(Review review);
        Review UpdateReview(int id, int revscore, int revsubject);
        bool RemoveReview(int id);
    }
}
