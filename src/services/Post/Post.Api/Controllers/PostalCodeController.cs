using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostalCodeController : ControllerBase
    {
        [HttpGet("CheckPostalCodeLen/{postalCode:int}")]
        public IActionResult CheckPostalCodeLen(int postalCode)
        {
            Thread.Sleep(5000);
            var result = postalCode.ToString().Length == 10;
            return Ok(new {result});
        }
    }
}
