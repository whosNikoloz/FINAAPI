using System;

namespace FINAAPI.Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public byte Type { get; set; }  // 0=text, 1=list
        public string Name { get; set; }  // Default name
        public string Name2 { get; set; }  // English
        public string Name3 { get; set; }  // Russian/Ukrainian
    }
} 