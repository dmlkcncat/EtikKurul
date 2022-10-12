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
    public class FormsController : ControllerBase
    {
        IFormService _petitionFormService;
        public FormsController(IFormService petitionFormService)
        {
            _petitionFormService = petitionFormService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _petitionFormService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Form petitionForm)
        {
            var result = _petitionFormService.Add(petitionForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Form petitionForm)
        {
            var result = _petitionFormService.Delete(petitionForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Form petitionForm)
        {
            var result = _petitionFormService.Update(petitionForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
