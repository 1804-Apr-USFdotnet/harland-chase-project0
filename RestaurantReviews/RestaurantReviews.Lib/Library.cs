using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Data;
using RestaurantReviews.Model;

namespace RestaurantReviews.Lib
{
    public enum SortBy { Alphabetical, Score, NumReviews };


    public class Library
    {
        private List<Restaurant> restaurants;
        private IDataManager dm;

        public Library()
        {
            dm = new AwsTsqlAccessor();
        }
        
        public void Sort(SortBy sortTerm, bool asc, int topN)
        {
            throw new NotImplementedException();
        }

        public  void Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
