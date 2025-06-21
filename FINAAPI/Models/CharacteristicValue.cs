using System;

namespace FINAAPI.Models
{
    public class CharacteristicValue
    {
        public int product_id { get; set; }
        public int characteristic_id { get; set; }
        public string value { get; set; }  // Default language
        public string value2 { get; set; }  // English
        public string value3 { get; set; }  // Russian/Ukrainian
    }
} 