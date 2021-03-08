using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTEST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        [HttpPost("UpdateDatabase")]
        public async Task<string> UpdateDatabase()
        {
            try
            {
                Dictionary<string, Datum> ItemsFromWarehouse = ConnectionWithRemonline.GetItemByArticle(await ConnectionWithRemonline.GetCollectionOfItems(), Repository.GetAllArticlesOfItemWhatWeNeed());
                //Repository.Add(ItemsFromWarehouse);
                try
                {
                    Repository.Update(ItemsFromWarehouse);
                }
                catch
                {
                    Repository.Add(ItemsFromWarehouse);
                }
                return "WarehouseItems has updated";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Обновление не удалось");
                return "Updating is fail";
            }
        }

        [HttpGet("accums")]
        public ActionResult<string> GetAccums()
        {
            var filtered = Repository.FetchAccumulatorData();
            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);
            return jsondata;
        }

        [HttpGet("disp-orig")]
        public ActionResult<string> GetDispOrig()
        {
            var filtered = Repository.FetchOrigDisplayData(); 
            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);
            return jsondata;
        }

        [HttpGet("disp-copy")]
        public ActionResult<string> GetDispCopy()
        {
            var filtered = Repository.FetchCopyDisplayData();
            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);
            return jsondata;
        }

        [HttpGet("main-cameras")]
        public ActionResult<string> GetCameras()
        {
            var filtered = Repository.FetchMainCamerasData();
            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);
            return jsondata;
        }
    }
}
