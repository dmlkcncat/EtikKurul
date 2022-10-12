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
    public class ApplicationQualificationsController : ControllerBase
    {
        IApplicationQualificationService _applicationQualificationService;
        public ApplicationQualificationsController(IApplicationQualificationService applicationQualificationService)
        {
            _applicationQualificationService = applicationQualificationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _applicationQualificationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(ApplicationQualification applicationQualification)
        {
            var result = _applicationQualificationService.Add(applicationQualification);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ApplicationQualification applicationQualification)
        {
            var result = _applicationQualificationService.Delete(applicationQualification);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ApplicationQualification applicationQualification)
        {
            var result = _applicationQualificationService.Update(applicationQualification);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _applicationQualificationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
