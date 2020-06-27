﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
    }
}
