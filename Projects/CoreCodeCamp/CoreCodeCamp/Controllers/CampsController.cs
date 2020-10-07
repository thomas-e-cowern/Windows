using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        
/*        public object Get()
        {
            return new { Moniker="ATL2014", Name="Atlanta Code Camp" };
        }*/

        [HttpGet]
        public IActionResult GetCamps()
        {
            return Ok(new { Moniker = "ATL2018", Name = "Atlanta Code Camp" });
        }

   
    }
}
