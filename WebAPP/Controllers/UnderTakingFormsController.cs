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
    public class UnderTakingFormsController : ControllerBase
    {
        IUnderTakingFormService _underTakingFormService;
        public UnderTakingFormsController(IUnderTakingFormService underTakingFormService)
        {
            _underTakingFormService = underTakingFormService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _underTakingFormService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(UnderTakingForm underTakingForm)
        {
            var result = _underTakingFormService.Add(underTakingForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UnderTakingForm underTakingForm)
        {
            var result = _underTakingFormService.Delete(underTakingForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UnderTakingForm underTakingForm)
        {
            var result = _underTakingFormService.Update(underTakingForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
