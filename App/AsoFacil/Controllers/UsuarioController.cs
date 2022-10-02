using AsoFacil.Models.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("usuario/modal")]
        public IActionResult Modal([FromBody] ManterUsuarioViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var usuario = GetByIdAsync(model.Id).Result;
                model.Login = usuario.Login;
            }

            return PartialView("_Modal", model);
        }

        #endregion

        #region Actions

        [HttpGet("usuario/getasync")]
        public async Task<IEnumerable<UsuarioViewModel>> GetAsync([FromQuery] string email)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/usuarios/v1/getasync?login={email}", null, TypeRequest.GetAsync, User);
            var usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(taskResult?.Data.ToString());
            return usuarios;
        }

        [HttpGet("usuario/getbyidasync")]
        public async Task<UsuarioViewModel> GetByIdAsync(Guid usuarioId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/usuarios/v1/getbyidasync/{usuarioId}", null, TypeRequest.GetAsync, User);
            var usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(taskResult?.Data.ToString());
            return usuario;
        }

        [HttpPost("usuario/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterUsuarioViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/usuarios/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("usuario/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterUsuarioViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/usuarios/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("usuario/deleteasync/{usuarioId}")]
        public async Task<ActionResult> DeleteAsync(Guid usuarioId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/usuarios/v1/deleteasync/{usuarioId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion
    }
}