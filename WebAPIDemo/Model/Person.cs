using System;
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
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        // public static IEnumerable<Person> GetPeople()
        // {
        //     return new List<Person>()
        //     {
        //         new Person(){ID=1, Name="Dara", EmailAddress="me@darao.com", Address=new Address(){State="Lagos", Country="NG", PostCode="101233", StreetName="Nice Street", StreetNumber=5 } },
        //         new Person(){ID=2,Name="ODara", EmailAddress="me@dara.com", Address=new Address(){State="London", Country="GB", PostCode="101253", StreetName="Very Nice Street", StreetNumber=6 } },
        //     };
        // }
    }
    public class AddPersonBindingModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
    }
    public class ModifyPersonBindingModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
    }
}
