using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YingG.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = new YingG.Services.ImportServices();
            var stations = import.FindStations();

            var db = new YingG.Repository.WaterRepository();
            stations.ToList().ForEach(station =>
            {
                db.AddProduct(station);
            });

        }
    }
}
