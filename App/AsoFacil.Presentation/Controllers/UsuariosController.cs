using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Usuario;
using AsoFacil.Presentation.Auth;
using AsoFacil.Presentation.Controllers.MultiTenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [ApiController]
    public class UsuariosController : MultiTenantController
    {
        private const string entity = "Usuário";

        /// <summary>
        /// Endpoint de autenticação de usuário
        /// </summary>
        /// <param name="tokenService"></param>
        /// <param name="usuarioApplicationService"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Routes.LOGIN)]
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
        [HttpPost(Routes.POST_USUARIOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromServices] IUsuarioApplicationService usuarioApplicationService, [FromBody] ManterUsuarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await usuarioApplicationService.CriarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.POST_USUARIOS)
                           : MessagesApi.Error(entity, Routes.POST_USUARIOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.POST_USUARIOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter todos os usuários
        /// </summary>
        /// <param name="service"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet(Routes.GET_USUARIOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IUsuarioApplicationService service, [FromQuery] string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<UsuarioModel>>(ModelState.GetErrors()));

            try
            {
                var usuarios = await service.ObterAsync(email, empresaId);
                return Ok(new TaskResult<IEnumerable<UsuarioModel>>(usuarios));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<UsuarioModel>>($"{MessagesApi.Exception(string.Format("{0}{1}", entity, "s"), Routes.GET_USUARIOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet(Routes.GETBYID_USUARIOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IUsuarioApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<UsuarioModel>(ModelState.GetErrors()));

            try
            {
                var usuario = await service.ObterPorIdAsync(id);
                return Ok(new TaskResult<UsuarioModel>(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<UsuarioModel>($"{MessagesApi.Exception(entity, Routes.GETBYID_USUARIOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut(Routes.PUT_USUARIOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] IUsuarioApplicationService service, [FromBody] ManterUsuarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.PUT_USUARIOS)
                           : MessagesApi.Error(entity, Routes.PUT_USUARIOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.PUT_EMPRESAS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para excluir um usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpDelete(Routes.DELETE_USUARIOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] IUsuarioApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(id);
                return Ok(new TaskResult<string>(
                   result ? MessagesApi.Sucess(entity, Routes.DELETE_USUARIOS, EntityGender.Feminino)
                          : MessagesApi.Error(entity, Routes.DELETE_USUARIOS, EntityGender.Feminino), null)
                   );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.DELETE_USUARIOS)} {ex.Message}"));
            }
        }
    }
}