using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<Person> Persons = new List<Person>() {
            new Person() {
                ID=1,
                Name="Dara",
                EmailAddress="me@dara.com",
                Phone="12233245",
                Address=new Address(){
                    State="Oyo",
                    Country="Nigeria",
                    PostCode="101525",
                    StreetName="Olaogun",
                    StreetNumber=4
                }
            },
            new Person() {
                ID=2,
                Name="Oluwadara",
                EmailAddress="me@dara.com",
                Phone="78674552",
                Address=new Address(){
                    State="Lagos",
                    Country="Nigeria",
                    PostCode="101244",
                    StreetName="Olaogun",
                    StreetNumber=4
                }
            } };

        [HttpGet("getallpeople")]
        public ActionResult<List<Person>> GetAllPeople()
        {
            return Persons;
        }
        [HttpGet("getperson/{ID}")]
        public ActionResult<Person> GetPerson(int ID)
        {
            var Person = Persons.FirstOrDefault(opt => opt.ID == ID);
            return Person;
        }
        [HttpPost("createperson")]
        public ActionResult<Person> CreatePerson([FromBody] Person Person)
        {
            return Person;
        }
        [HttpDelete("delete/{ID}")]
        public ActionResult DeletePerson(int ID)
        {
            var Person = Persons.FirstOrDefault(opt => opt.ID == ID);
            if (Person != null)
            {
                Persons.Remove(Person);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("changeinfo")]
        public ActionResult ModifyPerson([FromBody] Person Person)
        {
            var PersonToFind = Persons.FirstOrDefault(opt => opt.ID == Person.ID);
            PersonToFind = Person;
            return Ok("Modified");
        }
    }
}
