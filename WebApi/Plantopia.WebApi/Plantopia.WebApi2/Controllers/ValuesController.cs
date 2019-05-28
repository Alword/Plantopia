using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plantopia.WebApi2.Data.Model;
using Plantopia.WebApi2.Data.Model.Device;

namespace Plantopia.WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly PlantopiaDataContext context;

        public ValuesController(PlantopiaDataContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values/All
        [HttpGet("All")]
        public ActionResult<string> GetAll()
        {
            DateTime dateStart = DateTime.Now.AddMinutes(-30);
            DeviceData[] x = context.DeviceDatas.Where(d => d.Datetime > dateStart).ToArray();
            return Ok(x);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] DeviceData data)
        {
            context.DeviceDatas.Add(data);
            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
