using System;
using System.Collections.Generic;

namespace FINAAPI.Models
{
    public class ProductOutDocument
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string NumPfx { get; set; }
        public int Num { get; set; }
        public string Purpose { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
        public int Store { get; set; }
        public int User { get; set; }
        public int Staff { get; set; }
        public int Project { get; set; }
        public int Customer { get; set; }
        public bool IsVat { get; set; }
        public bool MakeEntry { get; set; }
        public int PayType { get; set; }
        public int PriceType { get; set; }
        public int WType { get; set; }
        public int TType { get; set; }
        public int TPayer { get; set; }
        public decimal WCost { get; set; }
        public bool Foreign { get; set; }
        public string DrvName { get; set; }
        public string TrStart { get; set; }
        public string TrEnd { get; set; }
        public string DriverId { get; set; }
        public string CarNum { get; set; }
        public string TrText { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Comment { get; set; }
        public int OverlapType { get; set; }
        public decimal OverlapAmount { get; set; }
        public List<AdditionalField> AddFields { get; set; }
        public List<ProductOutItem> Products { get; set; }
        public List<ServiceItem> Services { get; set; }
    }

    public class ProductOutItem
    {
        public int Id { get; set; }
        public int SubId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class ServiceItem
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
} 