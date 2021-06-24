using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTEST.Orders
{
    public class FinanceTransaction
    {
        [Key]
        public int pk { get; set; }
    }

    public class Status
    {
        [Key]
        public int bd_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int group { get; set; }
    }

    //public class CustomFields
    //{
    //    public string f316201 { get; set; }
    //    public string f316202 { get; set; }
    //    public string f316203 { get; set; }
    //    public string f316205 { get; set; }
    //    public string f316206 { get; set; }
    //    public string f316211 { get; set; }
    //}

    //public class AdCampaign
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //}

    public class Client
    {
        [Key]
        public int bd_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public List<string> phone { get; set; }
        public string notes { get; set; }
        public string address { get; set; }
        public bool supplier { get; set; }
        public bool juridical { get; set; }
        public bool conflicted { get; set; }
        public string modified_at { get; set; }
        public string created_at { get; set; }
        public string discount_code { get; set; }
        public double discount_goods { get; set; }
        public double discount_services { get; set; }
        public double discount_materials { get; set; }
        //public CustomFields custom_fields { get; set; }
        //public AdCampaign ad_campaign { get; set; }
    }

    public class Part
    {
        [Key]
        public int bd_id { get; set; }
        public int id { get; set; }
        public int engineer_id { get; set; }
        public string title { get; set; }
        public double amount { get; set; }
        public double price { get; set; }
        public double cost { get; set; }
        public double discount_value { get; set; }
        public int warranty { get; set; }
        public int warranty_period { get; set; }
    }

    public class Operation
    {
        [Key]
        public int bd_id { get; set; }
        public int id { get; set; }
        public int engineer_id { get; set; }
        public string title { get; set; }
        public double amount { get; set; }
        public double price { get; set; }
        public int cost { get; set; }
        public double discount_value { get; set; }
        public int warranty { get; set; }
        public int warranty_period { get; set; }
    }

    //public class Attachment
    //{
    //    public string created_at { get; set; }
    //    public int created_by_id { get; set; }
    //    public string filename { get; set; }
    //    public string url { get; set; }
    //}

    public class OrderType
    {
        [Key]
        public int bd_id { get; set;}
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Order
    {
        [Key]
        public int id { get; set; }
        public string modified_at { get; set; }
        public FinanceTransaction finance_transaction { get; set; }
        public Status status { get; set; }
        public string created_at { get; set; }
        public string done_at { get; set; }
        public Client client { get; set; }
        //public AdCampaign ad_campaign { get; set; }
        public string kindof_good { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string serial { get; set; }
        public string packagelist { get; set; }
        public string appearance { get; set; }
        public string malfunction { get; set; }
        public string manager_notes { get; set; }
        public string engineer_notes { get; set; }
        public string resume { get; set; }
        public int payed { get; set; }
        public double missed_payments { get; set; }
        public int warranty_measures { get; set; }
        public bool urgent { get; set; }
        public double discount_sum { get; set; }
        public List<string> resources { get; set; }
        //public CustomFields custom_fields { get; set; }
        public string estimated_cost { get; set; }
        public string closed_at { get; set; }
        public string estimated_done_at { get; set; }
        public string id_label { get; set; }
        public double price { get; set; }
        public int branch_id { get; set; }
        public bool overdue { get; set; }
        public bool status_overdue { get; set; }
        public List<Part> parts { get; set; }
        public List<Operation> operations { get; set; }
        //public List<Attachment> attachments { get; set; }
        public OrderType order_type { get; set; }
        public int manager_id { get; set; }
        public int engineer_id { get; set; }
        public int created_by_id { get; set; }
        public int closed_by_id { get; set; }
        public long? warranty_date { get; set; }
        public long? assigned_at { get; set; }
        public int? duration { get; set; }
        public long? scheduled_for { get; set; }
    }

    public class Root
    {
        public List<Order> data { get; set; }
        public int page { get; set; }
        public int count { get; set; }
        public bool success { get; set; }
    }


}
