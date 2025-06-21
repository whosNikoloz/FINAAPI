using System;
using System.Collections.Generic;

namespace FINAAPI.Models
{
    public class ProductUnit
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public double Quantity { get; set; }
        public string Barcode { get; set; }

        public List<UnitPrice> UnitPrices { get; set; }
    }

    public class UnitPrice
    {
        public string Field { get; set; }
        public double Value { get; set; }
    }
}
