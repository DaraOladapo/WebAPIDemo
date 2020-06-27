using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Model
{
    public class Address
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
