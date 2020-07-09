using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController: ControllerBase {
        private readonly ApplicationDbContext dbContext;
        public PersonController(ApplicationDbContext _dbContext) {
                dbContext = _dbContext;
            }
            [HttpGet("getpersons")]
        public ActionResult < IEnumerable < Person >> GetAll() {
            var Persons = dbContext.Persons.ToList();
            return Persons;
        }
    }
}