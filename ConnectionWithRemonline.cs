using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplicationTEST
{
    public class ConnectionWithRemonline
    {
        private static string responseToken { get; set; }

        public static async Task PostRequestAsync()
        {
            WebRequest request = WebRequest.Create("https://api.remonline.ru/token/new");
            request.Method = "POST"; 
            string data = "api_key=a49d338c1466430e9568ca6ea77c5cda";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string token = reader.ReadToEnd();
                    ConnectionWithRemonline.responseToken = token;
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен...");
        }

        private static async Task<string> GetToken()
        {
            await PostRequestAsync();
            var jsonResponceToken =  ConnectionWithRemonline.responseToken;
            ResponceToken responceToken = JsonConvert.DeserializeObject<ResponceToken>(jsonResponceToken);
            return responceToken.token;
            

        }

        public static string GetPageFromRemonline(string token,int page)
        {
            string url = $"https://api.remonline.ru/warehouse/goods/28208?page={page}&token={token}";

            using  (var webClient = new WebClient())
            {
                var response =  webClient.DownloadString(url);
                
                return response;
            }
            
        }

        public static async Task<List<Item>> GetCollectionOfItems(int pageCount = 31){
            List<Item> listItem = new List<Item>();
            for (var i = 1; i <= pageCount; i++)
            {
                string responceMessage = ConnectionWithRemonline.GetPageFromRemonline(await ConnectionWithRemonline.GetToken(), i);
                Item thing = JsonConvert.DeserializeObject<Item>(responceMessage);
                listItem.Add(thing);
            }
            return listItem;
        }

        public static Dictionary<string,Datum> GetItemByArticle(IEnumerable<Item> ListofItems,IEnumerable<string> arrayOfArticles)
        {
            Dictionary<string,Datum> itemsfromWarehouse = new Dictionary<string,Datum>();
        
            foreach(var s in ListofItems)
            {
                // Console.WriteLine(s.page);
                foreach(var p in s.data)
                {  
                    try
                    {
                        foreach(string i in arrayOfArticles ){
                            if (p.article == i)
                            {
                                itemsfromWarehouse.Add(p.article,p);    
                            }  
                            
                        }
                    }
                    catch (System.Exception)
                    {   if(p.article == null){
                            System.Console.WriteLine("У этой позиции отсутствует артикль :");
                            System.Console.WriteLine(p.title);

                        }else{
                            System.Console.WriteLine("У этой позиции отсутствует артикль или найдено совпадение:");
                            System.Console.WriteLine(p.title);
                            throw;
                        }
                    }
                    
                }
            }
            return itemsfromWarehouse;
        }

    }
}
