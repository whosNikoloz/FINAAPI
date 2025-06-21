using System;

namespace FINAAPI.Models
{
    public class ProductPrice
    {
        public int product_id { get; set; }
        public int price_id { get; set; }

        public decimal Price { get; set; }
        public decimal discount_price { get; set; }

        public string Currency { get; set; }

        public DateTime? discount_start { get; set; }
        public DateTime? discount_end { get; set; }
    }
}
