using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public PersonController()
        {

        }
        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            var Persons = Person.GetPeople();
            return Ok(Persons);
        }
        [HttpGet("get-person/{ID}")]
        public ActionResult<Person> GetPerson(int ID)
        {
            var _Person = Person.GetPeople().FirstOrDefault(opt => opt.ID == ID);
            if (_Person != null)
                return Ok(_Person);
            else
                return NotFound();
        }

        [HttpPost("createperson")]
        public ActionResult<Person> CreatePerson([FromBody] AddPersonBindingModel BindingModel)
        {
            var PersonToCreate = new Person()
            {
                ID = Person.GetPeople().ToList().Count + 1,
                Name = BindingModel.Name,
                Address = BindingModel.Address,
                EmailAddress = BindingModel.EmailAddress,
                Phone = BindingModel.Phone
            };
            //TODO: Use ORM to save info
            return Ok(PersonToCreate);
        }
        [HttpPut("modify/{ID}")]
        public ActionResult<Person> ModifyPerson(int ID, [FromBody] ModifyPersonBindingModel BindingModel)
        {
            var _Person = Person.GetPeople().FirstOrDefault(opt => opt.ID == ID);
            if (_Person != null)
            {

                _Person.Name = BindingModel.Name;
                _Person.Phone = BindingModel.Phone;
                _Person.EmailAddress = BindingModel.EmailAddress;
                _Person.Address = BindingModel.Address;

                //TODO: Use ORM to save info
                return Ok(_Person);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("delete/{ID}")]
        public ActionResult Delete(int ID)
        {
            var _Person = Person.GetPeople().FirstOrDefault(opt => opt.ID == ID);
            //TODO: Use ORM to remove person from list
            if (_Person != null)
                return NoContent();
            else
                return NotFound();
        }
    }
}
