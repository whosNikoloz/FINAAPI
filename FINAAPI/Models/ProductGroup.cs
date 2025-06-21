using System;

namespace FINAAPI.Models
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }  // English
        public string Name3 { get; set; }  // Russian/Ukrainian
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
} 