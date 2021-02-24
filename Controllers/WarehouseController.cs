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
                Repository.Update(ItemsFromWarehouse);
                
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
            var art = Repository.articlesOfAccums;
            List<Datum> data = Repository.FetchData();
            List<Datum> filtered = new List<Datum>();
            foreach (var article in art)
            {
                foreach (var item in data)
                {
                    if (item.article == article)
                    {
                        filtered.Add(item);
                    }
                }
            }

            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);
            return jsondata;
        }

        [HttpGet("disp")]
        public ActionResult<string> GetDisp()
        {
            var art = Repository.articlesOfDisplay;
            List<Datum> data = Repository.FetchData();
            List<Datum> filtered = new List<Datum>();
            foreach (var article in art)
            {
                foreach (var item in data)
                {
                    if (item.article == article)
                    {
                        filtered.Add(item);
                    }
                }
            }
            string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(filtered);
            Console.WriteLine(jsondata);

            return jsondata;
        }
    }
}
