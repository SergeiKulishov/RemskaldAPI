using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationTEST

{
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public object parent_id { get; set; }
    }

    public class Datum
    {
        //public int id { get; set; }
        public string code { get; set; }
        [Key]
        public string title { get; set; }
        //public string image { get; set; }
        public string article { get; set; }
        public double residue { get; set; }
        //public Category category { get; set; }
        //public string description { get; set; }
        //public int warranty { get; set; }
        //public int warranty_period { get; set; }
    }

    public class Item
    {
        public List<Datum> data { get; set; }
        public string page { get; set; }
        public int count { get; set; }
        public bool success { get; set; }
    }


}
