using AsoFacil.Models.TipoUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class TiposdeUsuarioController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("tipousuario/modal")]
        public IActionResult Modal([FromBody] ManterTipoUsuarioViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var tipoUsuario = GetByIdAsync(model.Id).Result;
                model.Codigo = tipoUsuario.Codigo;
                model.Descricao = tipoUsuario.Descricao;
                model.MenuSistema = tipoUsuario.MenuSistema;
            }

            return PartialView("_Modal", model);
        }

        #endregion Views

        #region Actions

        [HttpGet("tipousuario/getasync")]
        public async Task<IEnumerable<TipoUsuarioViewModel>> GetAsync([FromQuery] string codigo, [FromQuery] string descricao)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/tiposusuarios/v1/getasync?codigo={codigo}&descricao={descricao}", null, TypeRequest.GetAsync, User);
            var tiposUsuarios = JsonConvert.DeserializeObject<List<TipoUsuarioViewModel>>(taskResult?.Data.ToString());
            return tiposUsuarios;
        }

        [HttpGet("tipousuario/getbyidasync")]
        public async Task<TipoUsuarioViewModel> GetByIdAsync(Guid tipoUsuarioId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/tiposusuarios/v1/getbyidasync/{tipoUsuarioId}", null, TypeRequest.GetAsync, User);
            var tipoUsuario = JsonConvert.DeserializeObject<TipoUsuarioViewModel>(taskResult?.Data.ToString());
            return tipoUsuario;
        }

        [HttpPost("tipousuario/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterTipoUsuarioViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/tiposusuarios/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("tipousuario/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterTipoUsuarioViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/tiposusuarios/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("tipousuario/deleteasync/{tipoUsuarioId}")]
        public async Task<ActionResult> DeleteAsync(Guid tipoUsuarioId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/tiposusuarios/v1/deleteasync/{tipoUsuarioId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions
    }
}