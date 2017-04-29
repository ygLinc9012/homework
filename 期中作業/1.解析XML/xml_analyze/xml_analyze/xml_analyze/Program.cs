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

            List<Station> stationList=FindStations();

            SQLDataServer sqlDataServer = new SQLDataServer();
            sqlDataServer.AddProduct(stationList);
        }

        public static List<Station> FindStations()
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(@"C:\Users\user\Documents\GitHub\xml_analyze\xml_analyze\河川水位.xml");//isbn.xml  河川水位.xml

            XmlNamespaceManager nsmanager = new XmlNamespaceManager(XmlDoc.NameTable);
            nsmanager.AddNamespace("twed", "http://twed.wra.gov.tw/twedml/opendata");
            nsmanager.AddNamespace("gml", "http://www.opengis.net/gml/3.2");

            XmlNodeList LocationAddressLists = XmlDoc.SelectNodes("twed:TaiwanWaterExchangingData/twed:HydrologyRiverClass/twed:RiverStageObservatoryProfile/twed:LocationAddress", nsmanager);
            XmlNodeList ObservatoryNameLists = XmlDoc.SelectNodes("twed:TaiwanWaterExchangingData/twed:HydrologyRiverClass/twed:RiverStageObservatoryProfile/twed:ObservatoryName", nsmanager);
            XmlNodeList ElevationOfWaterLevelZeroPointLists = XmlDoc.SelectNodes("twed:TaiwanWaterExchangingData/twed:HydrologyRiverClass/twed:RiverStageObservatoryProfile/twed:ElevationOfWaterLevelZeroPoint", nsmanager);
            //twed:TaiwanWaterExchangingData/twed:HydrologyRiverClass/twed:RiverStageObservatoryProfile/twed:LocationAddress
            //TaiwanWaterExchangingData/HydrologyRiverClass/RiverStageObservatoryProfile/LocationAddress
            Console.WriteLine("中文站址\t\t中文站名\t\t\t水尺零點標高");
            Console.WriteLine("LocationAddress\t\tObservatoryName\t\tElevationOfWaterLevelZeroPoint");

            XmlNode LocationAddressNode;
            XmlNode ObservatoryNameNode;
            XmlNode ElevationOfWaterLevelZeroPointNode;
            String StrLocationAddress;
            String StrObservatoryName;
            String StrElevationOfWaterLevelZeroPoint;

            List<Station> stationList = new List<Station>();
            for (int i = 0; i < LocationAddressLists.Count; i++)//改成foreach?
            {
                LocationAddressNode = LocationAddressLists[i];
                ObservatoryNameNode = ObservatoryNameLists[i];
                ElevationOfWaterLevelZeroPointNode = ElevationOfWaterLevelZeroPointLists[i];
                StrLocationAddress = LocationAddressNode.InnerText;
                StrObservatoryName = ObservatoryNameNode.InnerText;
                StrElevationOfWaterLevelZeroPoint = ElevationOfWaterLevelZeroPointNode.InnerText;

                Station station = new Station();
                station.LocationAddress = StrLocationAddress;
                station.ObservatoryName = StrObservatoryName;
                station.ElevationOfWaterLevelZeroPoint = StrElevationOfWaterLevelZeroPoint;
                stationList.Add(station);

                Console.WriteLine(stationList.Last().LocationAddress + "\t" + stationList.Last().ObservatoryName + "\t" + stationList.Last().ElevationOfWaterLevelZeroPoint);
            }

            Console.ReadKey();

            return stationList;
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
