using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ShowDataController : Controller
    {
        // GET: ShowData
        public ActionResult Index()
        {
            var stationRepository = new YingG.Repository.ReserovirRepository();

            var reservoirs = stationRepository.GetProduct();
            var message = string.Format("共收到{0}筆監測站的資料<br/>", reservoirs.Count);
            reservoirs.ForEach(x =>
            {
                message += string.Format("測站名稱：{0},水庫名稱:{1},縣市名稱:{2},採樣日期:{3},測項名稱:{4},監測值:{5}<br/>",x.siteName, x.damName,x.county,x.sampleDate,x.itemName,x.itemValue);


            });
            return Content(message);
        }
    }
}