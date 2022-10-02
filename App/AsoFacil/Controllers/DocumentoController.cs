using AsoFacil.Models.Documento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class DocumentoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("documento/modal")]
        public IActionResult Modal([FromBody] ManterDocumentoViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var documento = GetByIdAsync(model.Id).Result;
            }

            return PartialView("_Modal", model);
        }

        #endregion

        #region Actions

        [HttpGet("documento/getasync")]
        public async Task<IEnumerable<DocumentoViewModel>> GetAsync([FromQuery] string descricao)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/documentos/v1/getasync?descricao={descricao}", null, TypeRequest.GetAsync, User);
            var documentos = JsonConvert.DeserializeObject<List<DocumentoViewModel>>(taskResult?.Data.ToString());
            return documentos;
        }

        [HttpGet("documento/getbyidasync")]
        public async Task<DocumentoViewModel> GetByIdAsync(Guid documentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/documentos/v1/getbyidasync/{documentoId}", null, TypeRequest.GetAsync, User);
            var documento = JsonConvert.DeserializeObject<DocumentoViewModel>(taskResult?.Data.ToString());
            return documento;
        }

        [HttpPost("documento/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterDocumentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/documentos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("documento/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterDocumentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/documentos/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("documento/deleteasync/{documentoId}")]
        public async Task<ActionResult> DeleteAsync(Guid documentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/documentos/v1/deleteasync/{documentoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion
    }
}