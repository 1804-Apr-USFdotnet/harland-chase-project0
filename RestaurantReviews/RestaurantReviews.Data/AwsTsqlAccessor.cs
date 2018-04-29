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
        
        public int AddRestaurant(Model.Restaurant restaurant)
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                Restaurant newRest = context.Restaurants.Add(restaurant);
                context.SaveChanges();
                return newRest.restid;
            }
        }

        public int AddReview(Model.Review review)
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                Review newRev = context.Reviews.Add(review);
                context.SaveChanges();
                return newRev.revid;
            }
        }

        public Model.Restaurant GetRestaurant(int id)
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                return context.Restaurants.Find(id);
            }
        }

        public Model.Restaurant[] GetRestaurants()
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                return context.Restaurants;
            }
        }

        public Model.Review GetReview(int id)
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                return context.Reviews.Find(id);
            }
        }

        public Model.Review[] GetReviews()
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                return context.Reviews;
            }
        }

        public bool RemoveRestaurant(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                var std = context.Reviews.Find(id);
                context.Reviews.Remove(std);
                context.SaveChanges();

                return std != null;
            }
        }

        public Model.Restaurant UpdateRestaurant(int id, string restname)
        {
            throw new NotImplementedException();
            using (var context = new RestaurantDBEntities())
            {
                var std = context.Restaurants.Find(id);
                std.restname = restname;

                context.SaveChanges();
                return std;
            }
        }

        public Model.Review UpdateReview(int id, int revscore, int revsubject)
        {
            throw new NotImplementedException();
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
