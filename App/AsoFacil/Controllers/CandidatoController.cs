using AsoFacil.Models.Anamnese;
using AsoFacil.Models.Candidato;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class CandidatoController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidatoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("candidato/modal")]
        public IActionResult Modal([FromBody] ManterCandidatoViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var candidato = GetByIdAsync(model.Id).Result;
                model.Nome = candidato.Nome;
                model.RG = candidato.RG;
                model.Email = candidato.Email;
            }

            ModelState.Clear();
            return PartialView("_Modal", model);
        }

        [HttpPost("candidato/modalanamnese")]
        public IActionResult ModalAnamnese([FromBody] ManterCandidatoViewModel model)
        {
            var anamnese = new AnamneseViewModel();
            if (model != null && model.Id != Guid.Empty)
            {
                anamnese = GetAnamneseByCandidatoIdAsync(model.Id).Result;
            }

            ModelState.Clear();
            return PartialView("_ModalAnamnese", anamnese);
        }

        #endregion Views

        #region Actions

        [HttpGet("candidato/getasync")]
        public async Task<IEnumerable<CandidatoViewModel>> GetAsync([FromQuery] string nome, [FromQuery] string rg, [FromQuery] string email)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getasync?nome={nome}&rg={rg}&email={email}", null, TypeRequest.GetAsync, User);
            var candidatos = JsonConvert.DeserializeObject<List<CandidatoViewModel>>(taskResult?.Data.ToString());
            return candidatos;
        }

        [HttpGet("candidato/getbyidasync")]
        public async Task<CandidatoViewModel> GetByIdAsync(Guid candidatoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getbyidasync/{candidatoId}", null, TypeRequest.GetAsync, User);
            var candidato = JsonConvert.DeserializeObject<CandidatoViewModel>(taskResult?.Data.ToString());
            return candidato;
        }

        [HttpGet("candidato/getanamnesebycandidatoidasync")]
        public async Task<AnamneseViewModel> GetAnamneseByCandidatoIdAsync(Guid candidatoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getanamnesebycandidatoidasync/{candidatoId}", null, TypeRequest.GetAsync, User);
            var anamnese = JsonConvert.DeserializeObject<AnamneseViewModel>(taskResult?.Data.ToString());
            return anamnese;
        }

        [HttpPost("candidato/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterCandidatoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/candidatos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("candidato/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterCandidatoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("candidato/deleteasync/{candidatoId}")]
        public async Task<ActionResult> DeleteAsync(Guid candidatoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/deleteasync/{candidatoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions

        [HttpGet("aso")]
        public async Task<ActionResult> GetAsync(DownloadRequest request)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getasobycandidatoanamneseidasync/{request.Candidato}/{request.Anamnese}", null, TypeRequest.GetAsync, User);
            var model = JsonConvert.DeserializeObject<ASOViewModel>(taskResult?.Data.ToString());           

            var doc = new PdfSharp.Pdf.PdfDocument();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var page = doc.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            var textFormatter = new XTextFormatter(graphics);
            var font = new XFont("Arial", 14);

            graphics.DrawString("ATESTADO DE SAÚDE OCUPACIONAL", font, XBrushes.Black, new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);
            graphics.DrawString("Exame Admissional", font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.TopCenter);
            graphics.DrawString($"Nome: {model.Nome}", font, XBrushes.Black, new XRect(20, 100, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString($"RG: {model.Documento}", font, XBrushes.Black, new XRect(20, 130, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString($"Email: {model.Email}", font, XBrushes.Black, new XRect(20, 160, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString($"Cargo: {model.Cargo}", font, XBrushes.Black, new XRect(20, 190, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString($"Nascimento: {model.DataNascimento}", font, XBrushes.Black, new XRect(20, 220, page.Width, page.Height), XStringFormats.TopLeft);

            graphics.DrawString($"CNPJ: {model.CNPJ}", font, XBrushes.Black, new XRect(20, 300, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString($"Razão Social: {model.RazaoSocial}", font, XBrushes.Black, new XRect(20, 330, page.Width, page.Height), XStringFormats.TopLeft);

            graphics.DrawString($"Resultado: {model.Status}", font, XBrushes.Black, new XRect(20, 400, page.Width, page.Height), XStringFormats.TopLeft);

            if (model.Status.ToUpper() == "INAPTO")
                graphics.DrawString($"Motivo: {model.MotivoInapto}", font, XBrushes.Black, new XRect(20, 430, page.Width, page.Height), XStringFormats.TopLeft);

            graphics.DrawString($"{model.Medico}", font, XBrushes.Black, new XRect(0, -70, page.Width, page.Height), XStringFormats.BottomCenter);
            graphics.DrawString($"{model.Local}, {model.Data}", font, XBrushes.Black, new XRect(0, -50, page.Width, page.Height), XStringFormats.BottomCenter);

            //doc.Save(Path.Combine(webRootPath, "aso", $"ASO-{model.Nome.Trim()}.pdf"));
            var pdfContent = new MemoryStream();
            doc.Save(pdfContent);
            return File(pdfContent.ToArray(), "application/pdf");

            //return File(System.IO.File.ReadAllBytes(
            //    Path.Combine(webRootPath, "aso", $"ASO-{model.Nome.Trim()}.pdf")), "application/pdf");

            //string webRootPath = _webHostEnvironment.WebRootPath;
            //var content = new StreamContent(pdfContent);
            //content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //content.Headers.ContentDisposition.FileName = $"ASO-{model.Nome}";
            //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            //content.Headers.ContentLength = pdfContent.GetBuffer().Length;
            //return File(content.ToArray(), "application/pdf");
        }
    }
}

[BindProperties]
public class DownloadRequest
{
    public string Candidato { get; set; }
    public string Anamnese { get; set; }
}