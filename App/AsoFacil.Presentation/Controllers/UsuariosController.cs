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
        [HttpPost("api/usuarios/v1/loginasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromServices] TokenService tokenService,
            [FromServices] IUsuarioApplicationService usuarioApplicationService, [FromBody] UsuarioLoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<UsuarioModel>(ModelState.GetErrors()));

            try
            {
                var user = await usuarioApplicationService.Login(model.Login, model.Senha);

                if (user == null || user.Id.Equals(Guid.Empty))
                    return StatusCode(401, new TaskResult<UsuarioModel>("Usuário ou senha inválidos."));

                user.Token = tokenService.GerarToken(user);                
                return Ok(new TaskResult<UsuarioModel>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<UsuarioModel>($"Ocorreu um erro ao realizar login no sistema! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint de criação de usuário
        /// </summary>
        /// <param name="usuarioApplicationService"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/usuarios/v1/postasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromServices] IUsuarioApplicationService usuarioApplicationService, [FromBody] CriarUsuarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var user = await usuarioApplicationService.CriarAsync(model);
                return Ok(new TaskResult<string>("Usuário cadastrado com sucesso!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao criar usuário! {ex.Message}"));
            }
        }
    }
}