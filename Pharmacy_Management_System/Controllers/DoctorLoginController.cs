using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pharmacy_Management_System.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Pharmacy_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorLoginController : ControllerBase
    {
        private IConfiguration _login;
        private readonly PharmacyContextDb _contextDb;
        public DoctorLoginController(IConfiguration config, PharmacyContextDb contextDb)
        {
            _login = config;
            _contextDb = contextDb;

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var user = Authenticate(login);
            try
            {
                if (user != null)
                {
                    var token = Generate(user);
                    var obj = new { Token = token };
                    return Ok(obj);

                }
            }
            catch (Exception ex)
            {
                return BadRequest("User Not Found"+ex);
            }
           return NotFound("User is invalid");
        }

        private string Generate(Doctor user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_login["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.EmailID),
                new Claim(ClaimTypes.NameIdentifier,user.Password),
                new Claim(ClaimTypes.NameIdentifier,user.DoctorName),
                //new Claim(ClaimTypes.MobilePhone,user.c),
               // new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_login["Jwt:Issuer"],
                                             _login["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Doctor Authenticate(Login login)
        {
            var CurrentUser = _contextDb.DoctorsDetails.FirstOrDefault(
                c => c.EmailID.ToLower() == login.EmailID.ToLower()
                && c.Password == login.Password);
           
                if (CurrentUser != null)
                {
                    return CurrentUser;
                }
                return null;

        }
    
    }
}
