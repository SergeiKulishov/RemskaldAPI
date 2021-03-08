using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationTEST
{
   public static class Repository
    {
        public static string[] articlesOfAccums { get; } = { "1010", "1020", "1030", "1050", "1060", "1070", "1080", "1090", "1110", "1120", "1128",
                                                             "1129", "1125","8895", "8897", "8896" };

        public static string[] articlesOfDisplayOrig { get; } = { "0501o", "0502o", "0601o","0602R", "0601R", "0601so", "0602sr", "0601po", "0602pR","0601spo",
                                                                  "0602spR","0701o","0702oR","0701pR","0702pR","8001","8004R","8004pR","8003pR","8002",
                                                                  "8005","4200","8006","1111","1112","1113"};
        
        public static string[] articlesOfDisplayCopy { get; } = {"0301", "0302", "0501s", "0502s", "0601", "0602", "0601s", "0602s", "0601p", "0602p",
                                                                 "0601sp", "0602sp","0701","0702","0702p","0702pw","8001c","8004k","8003k","8003p","8002c",
                                                                 "4200c","8006K","8005c"};

        public static string[] articlesOfMainCameras { get; } = {"4304","4604", "4504", "6185", "4704", "4804", "4934", "4914", "4904", "5040", "5030", "4206",
                                                                 "4206s","4208"};
 
        public static IEnumerable<string> GetAllArticlesOfItemWhatWeNeed()
        {

            var allArticles = new List<string>();

            foreach (var accum in articlesOfAccums)
            {
                allArticles.Add(accum);
            }

            foreach (var disp in articlesOfDisplayOrig) { 

                allArticles.Add(disp);
            }

            foreach (var disp in articlesOfDisplayCopy)
            {
                allArticles.Add(disp);
            }
            
            foreach (var cams in articlesOfMainCameras)
            {
                allArticles.Add(cams);
            }


            return allArticles;
        }

        public static void Add(Dictionary<string, Datum> itemsFromWarehouse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (KeyValuePair<string, Datum> kvp in itemsFromWarehouse)
                {
                    db.datums.Add(kvp.Value);
                }
                db.SaveChanges();
                Console.WriteLine("Объекты успешно добавлены");
            }
        }
            
        public static void Update(Dictionary<string, Datum> itemsFromWarehouse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (KeyValuePair<string, Datum> kvp in itemsFromWarehouse)
                {
                    db.datums.Update(kvp.Value);
                }
                db.SaveChanges();
                Console.WriteLine("Объекты успешно обновлены");
            }
        }

        public static List<Datum> FetchData()
        {
            List<Datum> items;

            using (ApplicationContext db = new ApplicationContext())
            {
                items = db.datums.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var i in items)
                {
                    Console.WriteLine(i.article + " - " + i.title + " Кол-во: " + i.residue);
                }
            }
            return items;
        }

        public static IEnumerable<Datum> FetchOrigDisplayData()
        {
            var art = Repository.articlesOfDisplayOrig;
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
            return filtered;
        }

        public static List<Datum> FetchCopyDisplayData()
        {
            var art = Repository.articlesOfDisplayCopy;
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
            return filtered;
        }

        public static List<Datum> FetchAccumulatorData()
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
            return filtered;
        }

        public static List<Datum> FetchMainCamerasData()
        {
            var art = Repository.articlesOfMainCameras;
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
            return filtered;
        }

    }
}
