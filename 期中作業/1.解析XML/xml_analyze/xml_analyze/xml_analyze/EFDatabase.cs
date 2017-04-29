using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_analyze
{
    class EFDatabase : System.Data.Entity.DbContext
    {
        /*public EFDatabase() : base("EFConnection") { }
        public EFDatabase(string connectionString) : base(connectionString) { }
        static EFDatabase()
        {
            System.Data.Entity.Database.SetInitializer<EFDatabase>(new EFDatabaseInit());
        }
        public System.Data.Entity.DbSet<Product> Products { get; set; }*/

    }
    /*public class EFDatabaseInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFDatabase>
    {
        protected override void Seed(EFDatabase context)
        {
            var product = new KUAS_SHOP.Models.Product();
            product.ID = 0;
            product.Title = "new";
            product.Name = "017first";
            product.Price = 99;
            product.Content = "Content";
            product.Brief_introduction = "Brief_introduction";
            product.CreateDateTime = DateTime.Now;
            product.Photo = "/Content/Images/Products/嘿嘿.jpg";

            context.Products.Add(product);
            context.SaveChanges();
        }
    }*/
}
