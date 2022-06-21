using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1retake.Services;

namespace Test1retake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IDatabaseService _service;
        public AlbumsController(IDatabaseService service)
        {
            _service = service;
        }
    }
}
