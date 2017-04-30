using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YingG.Model;

namespace YingG.Repository
{
    public class ReserovirRepository
    {
        public String GetconnectString()
        {
            String connectString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=water;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return connectString;
        }
        public List<Reservoir> GetProduct()
        {
            var result = new List<Reservoir>();
            var connectString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=reserovir;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Catalog是要看你SQL內部的資料庫名稱決定
            //不加@的話，  \會被判斷成指令  就像是想要印出\的話必須打成\\   加上@則只需打一個
            //另一種方式System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
            System.Data.SqlClient.SqlConnection connx = new System.Data.SqlClient.SqlConnection(connectString);
            connx.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = connx;
            comm.CommandText = "select * from data";

            System.Data.SqlClient.SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                YingG.Model.Reservoir reservoir = new YingG.Model.Reservoir();
                reservoir.siteName = reader["siteName"].ToString();
                reservoir.damName = reader["damName"].ToString();
                reservoir.county = reader["county"].ToString();
                reservoir.sampleDate = reader["sampleDate"].ToString();
                reservoir.itemName = reader["itemName"].ToString();
                reservoir.itemValue = reader["itemValue"].ToString();


                result.Add(reservoir);
            }
            connx.Close();
            return result;
        }
        public void AddReserovirData(List<Reservoir> reserovirList)
        {
            var connectString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=reserovir;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Catalog是要看你SQL內部的資料庫名稱決定
            //不加@的話，  \會被判斷成指令  就像是想要印出\的話必須打成\\   加上@則只需打一個
            //另一種方式System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
            System.Data.SqlClient.SqlConnection connx = new System.Data.SqlClient.SqlConnection(connectString);
            connx.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = connx;

            reserovirList.ToList().ForEach(reserovir => {
                comm.CommandText = string.Format(@"
INSERT INTO [data]
    ([siteName]
    ,[damName]
    ,[county]
    ,[sampleDate]
    ,[itemName]
    ,[itemValue])
VALUES
    (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')",
reserovir.siteName, reserovir.damName, reserovir.county, reserovir.sampleDate, reserovir.itemName, reserovir.itemValue);
                comm.ExecuteNonQuery();//繳交指令，寫在foreach外會只繳交一次
            });

            //前面加個N代表是unique code
            /*comm.CommandText可以用ide看他串起來結果如何
            再到sql ide試試看
            sql ide在資料表按又鍵會有一些資本語法可以用*/


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
