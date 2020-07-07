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
        private readonly IRepository _Repository;
        public PersonController(ApplicationDbContext dbContext, IRepository repository)
        {
            _ApplicationDbContext = dbContext;
            _Repository=repository;
        }
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
        {

            var _Persons= await _Repository.FindAll<Person>();
            return Ok(_Persons);
        }
        [HttpGet("get-person/{ID}")]
        public async Task<ActionResult<Person>> GetPerson(int ID)
        {
            var _Person=await _Repository.FindById<Person>(ID);
            if (_Person != null)
                return Ok(_Person);
            else
                return NotFound();
        }

        [HttpPost("createperson")]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] AddPersonBindingModel BindingModel)
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
            await _Repository.CreateAsync<Person>(PersonToCreate);
            return Created($"/get-person/{PersonToCreate.ID}", PersonToCreate);
            //return Ok(PersonToCreate);
        }
        [HttpPut("modify/{ID}")]
        public async Task<ActionResult<Person>> ModifyPerson(int ID, [FromBody] ModifyPersonBindingModel BindingModel)
        {
            var _Person = _ApplicationDbContext.Persons.FirstOrDefault(opt => opt.ID == ID);
            if (_Person != null)
            {
                _Person.Name = BindingModel.Name;
                _Person.Phone = BindingModel.Phone;
                _Person.EmailAddress = BindingModel.EmailAddress;
                _Person.Address = BindingModel.Address;
                await _Repository.UpdateAsync<Person>(_Person);
                return Ok(_Person);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("delete/{ID}")]
        public async Task<ActionResult> Delete(int ID)
        {
            var _Person=await _Repository.FindById<Person>(ID);
            if (_Person != null){
              await _Repository.DeleteAsync<Person>(_Person);
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
