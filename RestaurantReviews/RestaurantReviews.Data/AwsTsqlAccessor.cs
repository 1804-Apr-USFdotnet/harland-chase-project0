using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Model;
using System.Data.Entity;

namespace RestaurantReviews.Data
{
    public class AwsTsqlAccessor : IDataManager
    {
        
        public int AddRestaurant(Restaurant restaurant)
        {
            using (var context = new RestaurantDBEntities())
            {
                Restaurant newRest = context.Restaurants.Add(restaurant);
                context.SaveChanges();
                return newRest.restid;
            }
        }

        public int AddReview(Review review)
        {
            using (var context = new RestaurantDBEntities())
            {
                Review newRev = context.Reviews.Add(review);
                context.SaveChanges();
                return newRev.revid;
            }
        }

        public Restaurant GetRestaurant(int id)
        {
            using (var context = new RestaurantDBEntities())
            {
                return context.Restaurants.Find(id);
            }
        }

        public DbSet<Restaurant> GetRestaurants()
        {
            using (var context = new RestaurantDBEntities())
            {
                return context.Restaurants;
            }
        }

        public Review GetReview(int id)
        {
            using (var context = new RestaurantDBEntities())
            {
                return context.Reviews.Find(id);
            }
        }

        public DbSet<Review> GetReviews()
        {
            using (var context = new RestaurantDBEntities())
            {
                return context.Reviews;
            }
        }

        public bool RemoveRestaurant(int id)
        {
            using (var context = new RestaurantDBEntities())
            {
                var std = context.Restaurants.Find(id);
                context.Restaurants.Remove(std);
                context.SaveChanges();

                return std != null;
            }
        }

        public bool RemoveReview(int id)
        {
            using (var context = new RestaurantDBEntities())
            {
                var std = context.Reviews.Find(id);
                context.Reviews.Remove(std);
                context.SaveChanges();

                return std != null;
            }
        }

        public Restaurant UpdateRestaurant(int id, string restname)
        {
            using (var context = new RestaurantDBEntities())
            {
                var std = context.Restaurants.Find(id);
                std.restname = restname;

                context.SaveChanges();
                return std;
            }
        }

        public Review UpdateReview(int id, int revscore, int revsubject)
        {
            using (var context = new RestaurantDBEntities())
            {
                var std = context.Reviews.Find(id);
                std.revscore = revscore;
                std.revsubject = revsubject;

                context.SaveChanges();
                return std;
            }
        }
    }
}
