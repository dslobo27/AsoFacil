using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Usuario;
using AsoFacil.Presentation.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [ApiController]
    public class UsuariosController : Controller
    {
        /// <summary>
        /// Endpoint de autenticação de usuário
        /// </summary>
        /// <param name="tokenService"></param>
        /// <param name="usuarioApplicationService"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/usuarios/v1/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromServices] TokenService tokenService,
            [FromServices] IUsuarioApplicationService usuarioApplicationService, [FromBody] UsuarioLoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<UsuarioModel>(ModelState.GetErrors()));

            try
            {
                var user = await usuarioApplicationService.Login(model.Login, model.Senha);

                if (user.Id.Equals(Guid.Empty))
                    return StatusCode(401, new TaskResult<UsuarioModel>("Usuário ou senha inválidos."));

                user.Token = tokenService.GerarToken(user);                
                return Ok(new TaskResult<UsuarioModel>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<UsuarioModel>($"Ocorreu um erro ao realizar login no sistema! {ex.Message}"));
            }
        }
    }
}