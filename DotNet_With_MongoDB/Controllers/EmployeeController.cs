using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_With_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MongoDBServices _mongoDBServices;
        public EmployeeController(MongoDBServices mongoDBServices) => _mongoDBServices = mongoDBServices;

        [HttpGet]
        public async Task<List<Employee>> Get() => await _mongoDBServices.GetAsync();

        [HttpPost]
        public async Task Post([FromBody] Employee employee) => await _mongoDBServices.AddAsync(employee);
    }
}
