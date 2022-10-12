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
    public class UpdateApplicationsController : ControllerBase
    {
        IUpdateApplicationService _updateApplicationService;
        public UpdateApplicationsController(IUpdateApplicationService applicationService)
        {
            _updateApplicationService = applicationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _updateApplicationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(UpdateApplication application)
        {
            var result = _updateApplicationService.Add(application);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UpdateApplication application)
        {
            var result = _updateApplicationService.Delete(application);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateApplication application)
        {
            var result = _updateApplicationService.Update(application);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _updateApplicationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
