using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedApplicationsController : ControllerBase
    {
        IRedApplicationService _redApplicationService;
        public RedApplicationsController(IRedApplicationService redApplicationService)
        {
            _redApplicationService = redApplicationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _redApplicationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(RedApplication redApplication)
        {
            var result = _redApplicationService.Add(redApplication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _redApplicationService.Delete(new RedApplication() { Id = id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(RedApplication redApplication)
        {
            var result = _redApplicationService.Update(redApplication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _redApplicationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
