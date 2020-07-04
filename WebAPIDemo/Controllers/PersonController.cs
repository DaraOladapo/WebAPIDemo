using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Data;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ApplicationDbContext _ApplicationDbContext;
        public PersonController(ApplicationDbContext dbContext)
        {
            _ApplicationDbContext = dbContext;
        }
        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {

            var _Persons=_ApplicationDbContext.Persons.ToList();
            return Ok(_Persons);
        }
        [HttpGet("get-person/{ID}")]
        public ActionResult<Person> GetPerson(int ID)
        {
            var _Person=_ApplicationDbContext.Persons.FirstOrDefault(opt => opt.ID == ID);
            if (_Person != null)
                return Ok(_Person);
            else
                return NotFound();
        }

        [HttpPost("createperson")]
        public ActionResult<Person> CreatePerson([FromBody] AddPersonBindingModel BindingModel)
        { 
            var _Person=_ApplicationDbContext.Persons.FirstOrDefault(opt => opt.EmailAddress == BindingModel.EmailAddress);
            if (_Person != null)
                return Conflict();
            //check existing data before creating
            var PersonToCreate = new Person()
            {
                Name = BindingModel.Name,
                Address = BindingModel.Address,
                EmailAddress = BindingModel.EmailAddress,
                Phone = BindingModel.Phone,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            _ApplicationDbContext.Persons.Add(PersonToCreate);
            _ApplicationDbContext.SaveChanges();
            return Created($"/get-person/{PersonToCreate.ID}", PersonToCreate);
            //return Ok(PersonToCreate);
        }
        [HttpPut("modify/{ID}")]
        public ActionResult<Person> ModifyPerson(int ID, [FromBody] ModifyPersonBindingModel BindingModel)
        {
            var _Person = _ApplicationDbContext.Persons.FirstOrDefault(opt => opt.ID == ID);
            if (_Person != null)
            {
                _Person.Name = BindingModel.Name;
                _Person.Phone = BindingModel.Phone;
                _Person.EmailAddress = BindingModel.EmailAddress;
                _Person.Address = BindingModel.Address;
                _ApplicationDbContext.SaveChanges();
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
            var _Person = _ApplicationDbContext.Persons.FirstOrDefault(opt => opt.ID == ID);
            if (_Person != null){
                _ApplicationDbContext.Persons.Remove(_Person);
                _ApplicationDbContext.SaveChanges();
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
