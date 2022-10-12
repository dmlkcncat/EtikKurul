using Business.Abstract;
using DataAccess.Concrete;
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
    public class AllsController : ControllerBase
    {
        IApplicationService _applicationService;

        public AllsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            using (var context = new EtikContext())
            {
                return Ok(new
                {
                    ecpectedApplications = _applicationService.GetExpectedApplication().Data.Count,
                    completeApplications = _applicationService.GetCompleteApplication().Data.Count,
                    signatureExpectedApplications = _applicationService.GetSignatureExpected().Data.Count,
                    allApplications = _applicationService.GetDetail().Data.Count(),
                    updateExpectedApplications = _applicationService.GetUpdateExpected().Data.Count,
                    redApplications = _applicationService.GetRedApplication().Data.Count,
                });
            }
        }
    }
}
