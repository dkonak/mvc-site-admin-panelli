using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Slider { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsApproved{ get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}