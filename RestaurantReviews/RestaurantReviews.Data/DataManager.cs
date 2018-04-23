using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviews.Model;

namespace RestaurantReviews.Data
{
    public interface DataManager
    {
        Restaurant[] GetRestaurants();
        void addRestaurant(params Restaurant[] restaurants);
        void removeRestaurant(params Restaurant[] restaurants);

        Review[] GetReviews(Restaurant restaurant);
        void addReview(params Review[] reviews);
        void removeReview(params Review[] reviews);
    }
}
