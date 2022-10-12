using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Services;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
    public class UsersController : ControllerBase
    {
        IJWTAuthenticationManager _jWTAuthenticationManager;
        IUserService _userService;
        IMailService _mailService;

        public UsersController(IUserService userService, IMailService mailService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _userService = userService;
            _jWTAuthenticationManager = jWTAuthenticationManager;
            _mailService = mailService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] string eposta, [FromForm] string password)
        {

            User kullanici = _userService.Get(user => user.Eposta == eposta).Data;

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
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpGet("getDetail")]
        public IActionResult GetDetail()
        {
            var result = _userService.GetDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpGet("getMember")]
        public IActionResult GetMember()
        {
            var result = _userService.GetMember();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public IActionResult Add(User user2)
        {
            var user = new User
            {
                Address = user2.Address,
                Eposta = user2.Eposta,
                FullName = user2.FullName,
                Phone = user2.Phone,
                OfficePhone = user2.OfficePhone,
                RoleId = 4,
                Password = user2.Password,
            };
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("Memberadd")]
        public IActionResult MemberAdd(User user2)
        {
            var user = new User
            {
                Address = user2.Address,
                Eposta = user2.Eposta,
                FullName = user2.FullName,
                Phone = user2.Phone,
                OfficePhone = user2.OfficePhone,
                RoleId = 2,
                Password = "sdfahfYFSH",
            };
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("Sekretariatadd")]
        public IActionResult SekretariatAdd(User user2)
        {
            var user = new User
            {
                Address = user2.Address,
                Eposta = user2.Eposta,
                FullName = user2.FullName,
                Phone = user2.Phone,
                OfficePhone = user2.OfficePhone,
                RoleId = 3,
                Password = "sdfahfYFSH",
            };
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(new User() { Id = id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("updatePassword")]
        public IActionResult UpdatePassword(User user, string email, string password)

        {
            var result = _userService.UpdatePassword(user, email, password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("Active")]
        public IActionResult Active(User user)
        {

            var result = _userService.Active(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("StateActive")]
        public IActionResult StateActive(User user)
        {

            var result = _userService.StateActive(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [AllowAnonymous]
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
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
        
            var user = _userService.Get(user => user.Eposta == email).Data;
            var newPassword = FileService.generateRandomString();
            user.Password = newPassword;

            MailRequest mail = new MailRequest()
            {
                ToEmail = user.Eposta,
                Subject = "Yeni şifreniz",
                Body = newPassword,
            };
            await _mailService.SendEmailAsync(mail);
            _userService.Update(user);
            return Ok(new { message = "Mail adresinize yeni şifreniz gönderildi." });
        }
    }
}
