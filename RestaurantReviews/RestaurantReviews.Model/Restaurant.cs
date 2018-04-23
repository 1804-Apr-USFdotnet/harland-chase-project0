using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Model
{
    public class Restaurant
    {
        private readonly string name;
        private List<Review> reviews;

        public string Name { get { return name; } }
        public decimal AvgScore
        {
            get
            {
                var scores =
                    from review in reviews
                    select review.Score;

                return scores.Sum() / reviews.Count;
            }
        }

        public Restaurant(string name, Review[] reviews)
        {
            this.name = name;
            this.reviews = new List<Review>(reviews);
        }

        public Restaurant(string name) : this(name, new Review[] { }) { }

        public void addReview(Review r)
        {
            reviews.Add(r);
        }

        public Review[] getReviewArray()
        {
            return reviews.ToArray();
        }
    }
}
