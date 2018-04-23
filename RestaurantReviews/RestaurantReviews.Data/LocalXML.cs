using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Model;
using System.Xml.Serialization;
using System.IO;

namespace RestaurantReviews.Data
{
    public class LocalXML : DataManager
    {
        private List<Restaurant> restaurants;
        private List<Review> reviews;

        public LocalXML(string s)
        {
            XmlSerializer restSearial = new XmlSerializer(typeof(Restaurant));
            FileStream file;
            file = new FileStream(s, FileMode.Open);
            var rawData = restSearial.Deserialize(file);
        }

        public void addRestaurant(params Restaurant[] restaurants)
        {
            throw new NotImplementedException();
        }

        public void addReview(params Review[] reviews)
        {
            throw new NotImplementedException();
        }

        public Restaurant[] GetRestaurants()
        {
            throw new NotImplementedException();
        }


        public Review[] GetReviews(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public void removeRestaurant(params Restaurant[] restaurants)
        {
            throw new NotImplementedException();
        }

        public void removeReview(params Review[] reviews)
        {
            throw new NotImplementedException();
        }
    }
}
