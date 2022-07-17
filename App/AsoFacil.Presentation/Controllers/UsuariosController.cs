using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.Usuario;
using AsoFacil.Presentation.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : Controller
    {
        [HttpPost("/v1/login")]
        public async Task<IActionResult> PostAsync([FromServices] TokenService tokenService, 
            [FromServices] IUsuarioApplicationService usuarioApplicationService, [FromBody] UsuarioLoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var user = await usuarioApplicationService.Login(model.Login, model.Senha);

                if (user == null)
                    return StatusCode(401, new TaskResult<string>("Usuário ou senha inválidos."));

                var token = tokenService.GerarToken(user);
                return Ok(new TaskResult<string>(token, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao realizar login no sistema! {ex.Message}"));
            }
        }
    }
}