using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Seguranca;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alura.WebAPI.WebApp.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<Usuario> _signInManager;

        public LoginController(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Token(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var resultado = await _signInManager.PasswordSignInAsync(model.Login, model.Password, true, true);

                if (resultado.Succeeded)
                {
                    //cria Token(header + payload + signature)

                    var tokenString = "";

                    return Ok(tokenString);
                }
                return Unauthorized(); //401
            }
            return BadRequest(); //400
        }
    }
}
