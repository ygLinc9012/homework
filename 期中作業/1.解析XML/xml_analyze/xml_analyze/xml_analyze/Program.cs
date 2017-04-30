using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace xml_analyze
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Reservoir> reserovirList=FindStations();

            SQLDataServer sqlDataServer = new SQLDataServer();
            sqlDataServer.AddReserovirData(reserovirList);
        }

        public static List<Reservoir> FindStations()
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
                Console.WriteLine("側向名稱\t" + itemNameList[i].InnerText);
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

            Console.ReadKey();

            return reservoirList;
        }
    }
}
//筆記
/*
XmlNodeList NodeLists = XmlDoc.SelectNodes("twed:TaiwanWaterExchangingData/twed:HydrologyRiverClass/twed:RiverStageObservatoryProfile", nsmanager);
//兩條斜線是相對路徑的去選
//XmlNodeList rssItems2 = xd2.SelectNodes("//atom:feed/atom:entry", nsManager);
//一條斜線是從根路徑開始去選
//XmlNodeList rssItems2 = xd2.SelectNodes("/atom:feed/atom:entry", nsManager);
//沒有斜線是從目前的Node之下去選
//XmlNodeList rssItems2 = xd2.SelectNodes("atom:feed/atom:entry", nsManager);
//直接指定子節點去選
*/


//tmp.xml測試用
/*
XmlDocument XmlDoc = new XmlDocument();
XmlDoc.Load(@"D:\KUAS\C#\xml_analyze\tmp.xml");
XmlNodeList NodeLists = XmlDoc.SelectNodes("Root/MyLevel1");

foreach (XmlNode OneNode in NodeLists)
{
    String StrNodeName = OneNode.Name.ToString();
    foreach (XmlAttribute Attr in OneNode.Attributes)
    {
        String StrAttr = Attr.Name.ToString();//屬性名稱
        String StrValue = OneNode.Attributes[Attr.Name.ToString()].Value;//屬性名稱的值
        String StrInnerText = OneNode.InnerText;//節點內所有文字
        Console.WriteLine(StrAttr);
        Console.WriteLine(StrValue);
        Console.WriteLine(StrInnerText);
    }
}
Console.ReadKey();
*/
