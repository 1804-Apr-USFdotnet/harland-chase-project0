using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Model
{
    public class Review
    {
        public int Score { get; private set; }
        public string ReviewText { get; private set; }
        public string ReviewerName { get; private set; }
        
        public Review(string reviewerName, int score, string review)
        {
            ReviewerName = reviewerName;
            Score = score;
            ReviewText = review;
        }
    }
}
