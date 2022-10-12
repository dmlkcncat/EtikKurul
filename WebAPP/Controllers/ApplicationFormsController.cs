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
    public class ApplicationFormsController : ControllerBase
    {

        IApplicationFormService _applicationFormService;
        public ApplicationFormsController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _applicationFormService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(ApplicationForm applicationForm)
        {
            var result = _applicationFormService.Add(applicationForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ApplicationForm applicationForm)
        {
            var result = _applicationFormService.Delete(applicationForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ApplicationForm applicationForm)
        {
            var result = _applicationFormService.Update(applicationForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
