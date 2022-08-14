using AsoFacil.Models.Cargo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class CargoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("cargo/modal")]
        public IActionResult Modal([FromBody] ManterCargoViewModel model)
        {
            if(model != null && model.Id != Guid.Empty)
            {   
                var cargo = GetByIdAsync(model.Id).Result;
                model.Descricao = cargo.Descricao;
            }

            return PartialView("_Modal", model);
        }

        #endregion

        #region Actions

        [HttpGet("cargo/getasync")]
        public async Task<IEnumerable<CargoViewModel>> GetAsync([FromQuery] string descricao)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/cargos/v1/getasync?descricao={descricao}", null, TypeRequest.GetAsync, User);
            var cargos = JsonConvert.DeserializeObject<List<CargoViewModel>>(taskResult?.Data.ToString());
            return cargos;
        }

        [HttpGet("cargo/getbyidasync")]
        public async Task<CargoViewModel> GetByIdAsync(Guid cargoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/cargos/v1/getbyidasync/{cargoId}", null, TypeRequest.GetAsync, User);
            var cargo = JsonConvert.DeserializeObject<CargoViewModel>(taskResult?.Data.ToString());
            return cargo;
        }

        [HttpPost("cargo/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterCargoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/cargos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("cargo/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterCargoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/cargos/v1/putasync", model, TypeRequest.PutAsync, User);            
            return Json(taskResult);
        }

        [HttpDelete("cargo/deleteasync/{cargoId}")]
        public async Task<ActionResult> DeleteAsync(Guid cargoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/cargos/v1/deleteasync/{cargoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion
    }
}