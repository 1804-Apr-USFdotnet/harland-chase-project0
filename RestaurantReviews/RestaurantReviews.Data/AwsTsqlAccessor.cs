using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Model;

namespace RestaurantReviews.Data
{
    public class AwsTsqlAccessor : IDataManager
    {
        public bool AddRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public bool AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant[] GetRestaurants()
        {
            throw new NotImplementedException();
        }

        public Review GetReview(int id)
        {
            throw new NotImplementedException();
        }

        public Review[] GetReviews()
        {
            throw new NotImplementedException();
        }

        public bool RemoveRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReview(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant UpdateRestaurant(int id, Restaurant newValues)
        {
            throw new NotImplementedException();
        }

        public Review UpdateReview(int id, Review newValues)
        {
            throw new NotImplementedException();
        }
    }
}
