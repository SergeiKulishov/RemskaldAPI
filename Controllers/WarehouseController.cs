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
                Dictionary<string, Datum> itemsFromWarehouse = ConnectionWithRemonline.GetItemByArticle(await ConnectionWithRemonline.GetCollectionOfItems(), Repository.GetAllArticlesOfItemWhatWeNeed());
                //Repository.Add(ItemsFromWarehouse);
                try
                {
                    Repository.Update(itemsFromWarehouse);
                }
                catch
                {
                    Repository.Add(itemsFromWarehouse);
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

        [HttpGet("all-items")]
        public ActionResult<string> GetAllItems()
        {
            var filtered = Repository.FetchData();
            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);
            return jsondata;
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

        [HttpGet("cash-info")]
        public async Task<string> CashInfo()
        {
            string info = await ConnectionWithRemonline.GetCashboxInfo();
            var Boxes = Newtonsoft.Json.JsonConvert.DeserializeObject<Cashbox.CashboxesFromRemOnline>(info);
            Dictionary<int, Cashbox.Cashbox> GSCashboxes = new Dictionary<int, Cashbox.Cashbox>();
            foreach(var box in Boxes.data)
            {
                GSCashboxes.Add(box.id, box);
            }
            foreach(KeyValuePair<int,Cashbox.Cashbox> C in GSCashboxes)
            {
                Console.WriteLine($"Name : {C.Value.title}, Cash : {C.Value.balance} , ID : {C.Key}");
            }
            return info;
        }
    }
}
