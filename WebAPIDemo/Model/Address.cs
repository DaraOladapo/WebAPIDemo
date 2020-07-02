using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Model
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
