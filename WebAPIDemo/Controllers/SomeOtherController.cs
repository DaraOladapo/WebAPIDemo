using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SomeOtherController: ControllerBase {
        [HttpGet("getpeoplefromAPI")]
        public async Task<ActionResult<IEnumerable<MyPeople>>> GetPeopleFromAPI(){
            HttpClient httpClient=new HttpClient();
            var httpResponse=await httpClient.GetAsync("https://my.api.mockaroo.com/peopleforclass.json?key=9a55a0e0");
            var PeopleStringFromAPI=await httpResponse.Content.ReadAsStringAsync();
            var PeopleFromAPI=JsonConvert.DeserializeObject<List<MyPeople>>(PeopleStringFromAPI);
            return PeopleFromAPI;
        } 
    }
}