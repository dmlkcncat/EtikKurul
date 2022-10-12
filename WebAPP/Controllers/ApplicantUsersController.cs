using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Services;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI;

namespace WebAPP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantUsersController : ControllerBase
    {
        IJWTAuthenticationManager _jWTAuthenticationManager;
        IApplicantUserService _applicantUserService; 
        IMailService _mailService;
        public ApplicantUsersController(IApplicantUserService applicantUserService,
            IJWTAuthenticationManager jWTAuthenticationManager, IMailService mailService )
        {
            _applicantUserService = applicantUserService;
            _jWTAuthenticationManager = jWTAuthenticationManager;
            _mailService = mailService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] string eposta, [FromForm] string password)
        {

            ApplicantUser kullanici = _applicantUserService.Get(user => user.Eposta == eposta).Data;

            if (kullanici == null)
                return BadRequest(new ErrorResult(Messages.USER_NOT_FOUND));

            if (kullanici.Password != password)
                return BadRequest(new ErrorResult(Messages.USER_WRONG_PASSWORD));

            kullanici.Password = null;

            var token = _jWTAuthenticationManager.Authenticate(eposta);

            if (token == null) return Unauthorized();

            kullanici.Token = token;

            return Ok(kullanici);
        }

        [AllowAnonymous]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _applicantUserService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public IActionResult Add(ApplicantUser user2)
        {
            var user = new ApplicantUser
            {
                Address = user2.Address,
                Eposta = user2.Eposta,
                FullName = user2.FullName,
                Phone = user2.Phone,
                Password = user2.Password,
            };
            var result = _applicantUserService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public IActionResult Delete(ApplicantUser applicantUser)
        {
            var result = _applicantUserService.Delete(applicantUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public IActionResult Update(ApplicantUser applicantUser)
        {
            var result = _applicantUserService.Update(applicantUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {

            var user = _applicantUserService.Get(user => user.Eposta == email).Data;
            var newPassword = FileService.generateRandomString();
            user.Password = newPassword;

            MailRequest mail = new MailRequest()
            {
                ToEmail = user.Eposta,
                Subject = "Yeni şifreniz",
                Body = newPassword,
            };
            await _mailService.SendEmailAsync(mail);
            _applicantUserService.Update(user);
            return Ok(new { message = "Mail adresinize yeni şifreniz gönderildi." });
        }
    }
}
