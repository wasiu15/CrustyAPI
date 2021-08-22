using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ImageAddress{ get; set; }
        public int Discount { get; set; }
        public ICollection<test> tests { get; set; }
    }
}
