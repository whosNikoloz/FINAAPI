using System;

namespace FINAAPI.Models
{
    public class Store
    {
        public int Id { get; set; }
        public int group_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int project_id { get; set; }
    }
} 