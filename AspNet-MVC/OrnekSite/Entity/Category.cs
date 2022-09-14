using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<product> Products { get; set; }
    }
}