using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Model
{
    public class Restaurant
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AvgScore { get; private set; }
        private List<Review> reviews;

        public Restaurant(int id, string name)
        {
            Id = id;
            Name = name;
            AvgScore = 0;
            reviews = new List<Review>();
        }

        public void AddReview(Review r)
        {
            reviews.Add(r);
            AvgScore = AvgScore * (reviews.Count - 1) / reviews.Count + r.Score / reviews.Count;
        }

        public Review[] GetReviews()
        {
            return reviews.ToArray();
        }
    }
}
