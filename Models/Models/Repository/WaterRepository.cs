using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YingG.Model;

namespace YingG.Repository
{
    public class WaterRepository
    {
        public String GetconnectString()
        {
            String connectString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=water;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return connectString;
        }
        public List<Station> GetProduct()
        {
            var result = new List<Station>();
            var connectString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=water;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Catalog是要看你SQL內部的資料庫名稱決定
            //不加@的話，  \會被判斷成指令  就像是想要印出\的話必須打成\\   加上@則只需打一個
            //另一種方式System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
            System.Data.SqlClient.SqlConnection connx = new System.Data.SqlClient.SqlConnection(connectString);
            connx.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = connx;
            comm.CommandText = "select * from productDB";

            System.Data.SqlClient.SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                /*var product = new KUAS_SHOP.Models.Product();
                product.ID = int.Parse(reader["ID"].ToString());
                product.Price = int.Parse(reader["Price"].ToString());
                product.Title = reader["Title"].ToString();
                product.Name = reader["Name"].ToString();
                product.Content = reader["Content"].ToString();
                product.CreateDateTime = DateTime.Parse(reader["CreateDateTime"].ToString());
                result.Add(product);*/
                ;
            }
            connx.Close();
            return result;
        }
        public void AddProduct(Station station)
        {
            var connectString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=water;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Catalog是要看你SQL內部的資料庫名稱決定
            //不加@的話，  \會被判斷成指令  就像是想要印出\的話必須打成\\   加上@則只需打一個
            //另一種方式System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
            System.Data.SqlClient.SqlConnection connx = new System.Data.SqlClient.SqlConnection(connectString);
            connx.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = connx;

            comm.CommandText = string.Format(@"
INSERT INTO [Stations]
    ([LocationAddress]
    ,[ObservatoryName]
    ,[ElevationOfWaterLevelZeroPoint])
VALUES
    (N'{0}',N'{1}',N'{2}')",
station.LocationAddress, station.ObservatoryName, station.ElevationOfWaterLevelZeroPoint);
            //前面加個N代表是unique code
            /*comm.CommandText可以用ide看他串起來結果如何
            再到sql ide試試看
            sql ide在資料表按又鍵會有一些資本語法可以用*/


            comm.ExecuteNonQuery();
            connx.Close();
        }
        public void DeleteProduct(int id)
        {
            var connectString = @"Data Source=B1020518\SQLEXPRESS;Initial Catalog=myDB;Integrated Security=True";
            //Catalog是要看你SQL內部的資料庫名稱決定
            //不加@的話，  \會被判斷成指令  就像是想要印出\的話必須打成\\   加上@則只需打一個
            //另一種方式System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
            System.Data.SqlClient.SqlConnection connx = new System.Data.SqlClient.SqlConnection(connectString);
            connx.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = connx;

            comm.CommandText = string.Format(@"Delete From productDB where ID='{0}'", id);

            comm.ExecuteNonQuery();

            connx.Close();
        }
    }
}
