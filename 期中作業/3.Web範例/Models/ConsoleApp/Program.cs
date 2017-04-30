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
            var reservoirs = import.FindStations();

            var db = new YingG.Repository.ReserovirRepository();
            db.AddReserovirData(reservoirs);

        }
    }
}
