using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToApi.Controllers
{
    [ApiController]
    [Route("person/[action]")]
    public class PersonController : ControllerBase
    {
        public string SayHi()
        {
            return "Hi!";
        }
    }
}
