using efcv2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace efcv2.Controllers
{
    public class DataRetrievalController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        private efcv2DBEntities db = new efcv2DBEntities();

        // GET: DataRetrieval
        public ActionResult Index()
        {
            try
            {
                List<DataPoint> mList = new List<DataPoint>();
                foreach(Valuesi entry in db.Valuesis)
                {
                    DataPoint point = new DataPoint();
                    point.X = entry.ValueiID;
                    point.Y = Double.Parse(entry.Value);
                    mList.Add(point);
                }
                ViewBag.DataPoints = JsonConvert.SerializeObject(mList, _jsonSetting);
                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }

       
    }
}
