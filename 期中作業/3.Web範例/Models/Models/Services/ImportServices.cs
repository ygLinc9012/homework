using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using YingG.Model;

namespace YingG.Services
{
    public class ImportServices
    {
        public List<Reservoir> FindStations()
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(@"C:\Users\user\Desktop\reserovir.xml");//isbn.xml  河川水位.xml
            //C:\Users\user\Documents\GitHub\xml_analyze\xml_analyze\2016temperature.xml

            XmlNamespaceManager nsmanager = new XmlNamespaceManager(XmlDoc.NameTable);

            XmlNodeList siteNameList = XmlDoc.SelectNodes("WQXDam/Data/SiteName", nsmanager);
            XmlNodeList damNameList = XmlDoc.SelectNodes("WQXDam/Data/DamName", nsmanager);
            XmlNodeList countyList = XmlDoc.SelectNodes("WQXDam/Data/County", nsmanager);
            XmlNodeList sampleDateList = XmlDoc.SelectNodes("WQXDam/Data/SampleDate", nsmanager);
            XmlNodeList itemValueList = XmlDoc.SelectNodes("WQXDam/Data/ItemValue", nsmanager);
            XmlNodeList itemNameList = XmlDoc.SelectNodes("WQXDam/Data/ItemName", nsmanager);
            

            //twed:TaiwanWaterExchangingData/twed:HydrologyRiverClass/twed:RiverStageObservatoryProfile/twed:LocationAddress
            //TaiwanWaterExchangingData/HydrologyRiverClass/RiverStageObservatoryProfile/LocationAddress
            Console.WriteLine("時間\t\t地點\t\t名稱\t\t數值");
            Console.WriteLine("dataTime\tlocationName\telementName\telementValue");
            
            List<Reservoir> reservoirList = new List<Reservoir>();
            for (int i = 0; i < siteNameList.Count; i++)//改成foreach?
            {
                
                Console.WriteLine("測站名稱\t"+siteNameList[i].InnerText);
                Console.WriteLine("水庫名稱\t" + damNameList[i].InnerText);
                Console.WriteLine("縣市\t\t" + countyList[i].InnerText);
                Console.WriteLine("採樣日期\t" + sampleDateList[i].InnerText);
                Console.WriteLine("測項名稱\t" + itemNameList[i].InnerText);
                Console.WriteLine("監測值\t\t" + itemValueList[i].InnerText);
                Console.WriteLine();

                Reservoir reservoir = new Reservoir();
                reservoir.siteName = siteNameList[i].InnerText;
                reservoir.damName = damNameList[i].InnerText;
                reservoir.county = countyList[i].InnerText;
                reservoir.sampleDate = sampleDateList[i].InnerText;
                reservoir.itemValue = itemValueList[i].InnerText;
                reservoir.itemName = itemNameList[i].InnerText;

                reservoirList.Add(reservoir);
            }
            Console.WriteLine();
            Console.WriteLine("按下任意鍵寫入資料庫");

            Console.ReadKey();

            return reservoirList;
        }
    }
}
