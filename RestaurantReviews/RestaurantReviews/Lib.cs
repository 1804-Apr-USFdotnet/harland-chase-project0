using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using RestaurantReviews.Data;

namespace RestaurantReviews.lib
{
    public class Lib
    {
        private DataManager dm;

        public Lib()
        {
            var dataMan = ConfigurationManager.AppSettings["DataManager"];

            if (dataMan == "LocalXML")
            {
                var path = ConfigurationManager.AppSettings["LocalDataPath"];
                dm = new LocalXML(path + "data.xml");
            }
            else if (dataMan == "SQLDatabase")
            {
                //var address = ConfigurationManager.AppSettings["SQLAddress"];
                //dm = new SQLData();
                throw new NotImplementedException();
            } else
            {
                dm = new LocalXML("data/data.xml");
            }
        }


    }
}
