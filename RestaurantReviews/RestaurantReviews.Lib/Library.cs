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
        private List<Model.Restaurant> restaurants;
        private IDataManager dm;

        public Library(string mode)
        {
            if (mode.ToLower() == "test")
            {
                dm = new LocalTestData();
            }
            else
            {
                dm = new AwsTsqlAccessor();
            }
            restaurants = new List<Model.Restaurant>(dm.GetRestaurants());
        }

        public Library()
        {
            dm = new AwsTsqlAccessor();
            restaurants = new List<Model.Restaurant>(dm.GetRestaurants());
        }

        
        public Model.Restaurant[] Sort(SortBy sortTerm, bool asc, int topN)
        {
            throw new NotImplementedException();
        }

        public Model.Restaurant[] Sort(SortBy sortTerm, bool asc)
        {
            return Sort(sortTerm, asc, -1);
        }


        public Model.Restaurant[] Search(string[] searchTerms)
        {
            throw new NotImplementedException();
        }

        public Model.Restaurant[] Search(string term)
        {
            return Search(new string[] { term });
        }

        public Model.Review[] GetReviews(string restaurantName)
        {
            throw new NotImplementedException();
        }

        public void AddReview(int restaurantId, int score)
        {
            Model.Restaurant rest = RestLookup(restaurantId);
            int newId = dm.AddReview(new Model.Review(-1, score), restaurantId);
            rest.AddReview(new Model.Review(newId, score));
        }

        private Model.Restaurant RestLookup(string name)
        {
            throw new NotImplementedException();
        }

        private Model.Restaurant RestLookup(int id)
        {
            throw new NotImplementedException();
        }
    }
}
