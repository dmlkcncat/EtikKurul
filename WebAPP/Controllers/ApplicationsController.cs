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
    public class ApplicationsController : ControllerBase
    {
        IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _applicationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getDetail")]
        public IActionResult GetDetail()
        {
            var result = _applicationService.GetDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getAllById")]
        public IActionResult GetAllById(int id)
        {
            var result = _applicationService.GetAllById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getExpectedApplication")]
        public IActionResult GetExpectedApplication()
        {
            var result = _applicationService.GetExpectedApplication();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getCompleteApplication")]
        public IActionResult GetCompleteApplication()
        {
            var result = _applicationService.GetCompleteApplication();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getRedApplication")]
        public IActionResult GetRedApplication()
        {
            var result = _applicationService.GetRedApplication();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getSignatureExpected")]
        public IActionResult GetSignatureExpected()
        {
            var result = _applicationService.GetSignatureExpected();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getUpdateExpected")]
        public IActionResult GetUpdateExpected()
        {
            var result = _applicationService.GetUpdateExpected();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Application application)
        {
            var result = _applicationService.Add(application);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Application application)
        {
            var result = _applicationService.Delete(application);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Application application)
        {
            var result = _applicationService.Update(application);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _applicationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
