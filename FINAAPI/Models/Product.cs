using System;
using System.Collections.Generic;

namespace FINAAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Name_eng { get; set; }
        public string Name_rus { get; set; }
        public byte Vat { get; set; }  // 1=taxed, 2=zero, 3=exempt
        public string MinQuantity { get; set; }
        public List<AdditionalField> AddFields { get; set; }
    }

    public class AdditionalField
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }
} 