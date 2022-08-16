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
    public class AdminLoginController : ControllerBase
    {
        private IConfiguration _login;
        public AdminLoginController(IConfiguration config)
        {
            _login = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]Login login)
        {
            var user = Authenticate(login);

            if (user != null)
            {
                var token = Generate(user);
                var obj = new { Token = token };
                return Ok(obj);

            }
            return BadRequest();
        }

        private string Generate(Admin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_login["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.EmailID),
                new Claim(ClaimTypes.NameIdentifier,user.Password),
                new Claim(ClaimTypes.NameIdentifier,user.AdminName),
                new Claim(ClaimTypes.MobilePhone,user.Contact),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_login["Jwt:Issuer"],
                                             _login["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Admin Authenticate(Login adminlogin)
        {
            var CurrentUser = AdminConstants._admin.FirstOrDefault(
                c => c.EmailID.ToLower() == adminlogin.EmailID.ToLower()
                && c.Password==adminlogin.Password);
            if(CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }
    }
}
