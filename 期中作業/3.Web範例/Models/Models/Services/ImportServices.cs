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
        public List<Station> FindStations()
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

                Console.WriteLine(StrLocationAddress + "\t" + StrObservatoryName + "\t" + StrElevationOfWaterLevelZeroPoint);
            }

            Console.ReadKey();
            return stationList;
        }
    }
}
