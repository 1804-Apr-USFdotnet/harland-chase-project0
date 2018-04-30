using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Model
{
    public class Review
    {
        public int Id { get; private set; }
        public int Score { get; private set; }

        public Review(int id, int score)
        {
            Score = score;
        }
    }
}
