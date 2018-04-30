using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Lib;
using RestaurantReviews.Model;

namespace RestaurantReviews.LibTest
{
    [TestClass]
    public class LibTest
    {
        [TestMethod]
        public void SortTest1()
        {
            Library lib = new Library("test");
            SortBy sortScheme = SortBy.Alphabetical;
            bool asc = true;
            int n = 3;

            Restaurant[] restaurants = lib.Sort(sortScheme, asc, n);

            Assert.Equals(restaurants.Length, n);
            Assert.Equals(restaurants[0].Name, "Hard_Rock_Cafe");
            Assert.Equals(restaurants[1].Name, "McDonald's");
            Assert.Equals(restaurants[2].Name, "Olive_Garden");
        }

        [TestMethod]
        public void SortTest2()
        {
            Library lib = new Library("test");
            SortBy sortScheme = SortBy.Score;
            bool asc = true;
            int n = 3;

            Restaurant[] restaurants = lib.Sort(sortScheme, asc, n);

            Assert.Equals(restaurants.Length, n);
            Assert.Equals(restaurants[0].Name, "McDonald's");
            Assert.Equals(restaurants[1].Name, "Subway");
            Assert.Equals(restaurants[2].Name, "Olive_Garden");
        }


        [TestMethod]
        public void SortTest3()
        {
            Library lib = new Library("test");
            SortBy sortScheme = SortBy.Score;
            bool asc = false;
            int n = 3;

            Restaurant[] restaurants = lib.Sort(sortScheme, asc, n);

            Assert.Equals(restaurants.Length, n);
            Assert.Equals(restaurants[0].Name, "Hard_Rock_Cafe");
            Assert.Equals(restaurants[1].Name, "Olive_Garden");
            Assert.Equals(restaurants[2].Name, "Subway");
        }

        [TestMethod]
        public void SortTest4()
        {
            Library lib = new Library("test");
            SortBy sortScheme = SortBy.Score;
            bool asc = false;
            int n = 4;

            Restaurant[] restaurants = lib.Sort(sortScheme, asc);

            Assert.Equals(restaurants.Length, n);
            Assert.Equals(restaurants[0].Name, "Hard_Rock_Cafe");
            Assert.Equals(restaurants[1].Name, "Olive_Garden");
            Assert.Equals(restaurants[2].Name, "Subway");
            Assert.Equals(restaurants[3].Name, "McDonald's");
        }


        [TestMethod]
        public void SortTest5()
        {
            Library lib = new Library("test");
            SortBy sortScheme = SortBy.NumReviews;
            bool asc = false;
            int n = 1;

            Restaurant[] restaurants = lib.Sort(sortScheme, asc);

            Assert.Equals(restaurants.Length, n);
            Assert.Equals(restaurants[0].Name, "McDonald's");
        }

    }
}
