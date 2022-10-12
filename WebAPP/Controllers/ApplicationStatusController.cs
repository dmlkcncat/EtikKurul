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
    public class ApplicationStatusController : ControllerBase
    {
        IApplicationStatusService _applicationStatusService;
        public ApplicationStatusController(IApplicationStatusService applicationStatusService)
        {
            _applicationStatusService = applicationStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _applicationStatusService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(ApplicationStatus applicationStatus)
        {
            var result = _applicationStatusService.Add(applicationStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ApplicationStatus applicationStatus)
        {
            var result = _applicationStatusService.Delete(applicationStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ApplicationStatus applicationStatus)
        {
            var result = _applicationStatusService.Update(applicationStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _applicationStatusService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
