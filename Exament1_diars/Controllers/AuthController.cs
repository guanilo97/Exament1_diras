using Exament1_diars.BD;
using Exament3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exament1_diars.Controllers
{
    public class AuthController : Controller
    {
        private AppBlogContext context;
        private IConfiguration configuration;
        public AuthController(AppBlogContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.usuarios
               .FirstOrDefault(o => o.Username == username && o.Password == CreateHash(password));
            //  var user = context.Usuarios.FirstOrDefault(o => o.Username == usernme && o.Password == CreateHash(password));
            if (user == null)
            {
                TempData["AuthMessaje"] = "Usuario o password incorrectos";
                return RedirectToAction("Login");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),

            };
            //session[];

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Logaut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Create()
        {
            var user = context.usuarios.ToList();
            return View(user);
            //return CreateHash(password);
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuario.Password = CreateHash(usuario.Password);
            context.usuarios.Add(usuario);
            context.SaveChanges();
            return RedirectToAction("Login");
        }
        private string CreateHash(string input)
        {
            input += configuration.GetValue<string>("Key");
            var sha = SHA512.Create();
            var bytes = Encoding.Default.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
