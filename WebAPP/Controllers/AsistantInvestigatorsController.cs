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
    public class AsistantInvestigatorsController : ControllerBase
    {
        IAsistantInvestigatorService _asistantInvestigatorService;
        public AsistantInvestigatorsController(IAsistantInvestigatorService asistantInvestigatorService)
        {
            _asistantInvestigatorService = asistantInvestigatorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _asistantInvestigatorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(AssistantInvestigator asistantInvestigator)
        {
            var result = _asistantInvestigatorService.Add(asistantInvestigator);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AssistantInvestigator asistantInvestigator)
        {
            var result = _asistantInvestigatorService.Delete(asistantInvestigator);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(AssistantInvestigator asistantInvestigator)
        {
            var result = _asistantInvestigatorService.Update(asistantInvestigator);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _asistantInvestigatorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
