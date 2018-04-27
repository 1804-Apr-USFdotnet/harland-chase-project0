using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Data;
using RestaurantReviews.Model;
using System.Data;
using System.Data.Entity;

namespace RestaurantReviews.Lib
{
    public enum SortBy { Alphabetical, Score, NumReviews };


    public class Library
    {
        private List<Restaurant> restaurants;
        private List<Review> reviews;
        private IDataManager dm;

        public Library()
        {
            dm = new AwsTsqlAccessor();
        }
        
        public Restaurant[] Sort(SortBy sortTerm, bool asc, int topN)
        {
            throw new NotImplementedException();
        }

        public Restaurant[] Sort(SortBy sortTerm, bool asc)
        {
            return Sort(sortTerm, asc, -1);
        }

        public  void Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
