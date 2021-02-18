using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTEST

{
    public class Repository
    {
        public static string[] articlesOfAccums { get; } = { "1010", "1020", "1030", "1050", "1060", "1070", "1080", "1090", "1120", "1128", "1129", "1125" };
        public static string[] articlesOfDisplay { get; } = { "0601", "0601s", "0602", "0602s", "0601p", "0601sp", "0602p", "0602sp" };

        public static IEnumerable<string> GetAllArticlesOfItemWhatWeNeed()
        {

            var allArticles = new List<string>();

            foreach (var accum in articlesOfAccums)
            {
                allArticles.Add(accum);
            }
            foreach (var disp in articlesOfDisplay)
            {
                allArticles.Add(disp);
            }

            return allArticles;
        }

        public static void Add(Dictionary<string, Datum> ItemsFromWarehouse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (KeyValuePair<string, Datum> kvp in ItemsFromWarehouse)
                {
                    // добавляем их в бд
                    db.Datums.Add(kvp.Value);
                }
                db.SaveChanges();
                Console.WriteLine("Объекты успешно добавлены");
            }
        }
            
        public static void Update(Dictionary<string, Datum> ItemsFromWarehouse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (KeyValuePair<string, Datum> kvp in ItemsFromWarehouse)
                {
                    //обновляем их в бд
                    db.Datums.Update(kvp.Value);
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
                // получаем объекты из бд и выводим на консоль
                items = db.Datums.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var i in items)
                {
                    Console.WriteLine(i.article + " - " + i.title + " Кол-во: " + i.residue);
                }
            }
            return items;
        }
    }
}
