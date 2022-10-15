using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.SolicitacaoAtivacaoEmpresa;
using AsoFacil.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsoFacil.Tests
{
    public class SolicitacoesAtivacoesEmpresasControllerTest
    {
        private readonly ClaimsPrincipal _user;
        private readonly SolicitacoesAtivacoesEmpresasController _controller;
        private readonly ISolicitacaoAtivacaoEmpresaApplicationService _service;

        public SolicitacoesAtivacoesEmpresasControllerTest()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("EMPRESA_ID", Guid.NewGuid().ToString()),
                new Claim("COD_TIPO_USUARIO", "ASOFACIL_ADMIN")
            }, "mock"));

            _controller = Substitute.For<SolicitacoesAtivacoesEmpresasController>();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = _user };

            _service = Substitute.For<ISolicitacaoAtivacaoEmpresaApplicationService>();
        }

        [Fact]
        public async Task ShouldGetAsync()
        {
            _service.ObterParaAtivacaoAsync()
                .ReturnsForAnyArgs(new List<SolicitacaoAtivacaoEmpresaModel> {
                    new SolicitacaoAtivacaoEmpresaModel()
                });

            var result = _controller.GetAsync(_service);

            await _service.Received().ObterParaAtivacaoAsync();

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenGetAsync()
        {
            _service.ObterParaAtivacaoAsync().TaskThrowsException();

            var result = _controller.GetAsync(_service);

            await _service.Received().ObterParaAtivacaoAsync();

            Assert.Null(result.Result);
        }
                
        [Fact]
        public async Task ShouldPutAsync()
        {
            var id = Guid.NewGuid();

            _service.AlterarAsync(id)
                .ReturnsForAnyArgs(new SolicitacaoAtivacaoEmpresaModel());

            var result = _controller.PutAsync(_service, id);

            await _service.Received().AlterarAsync(id);

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenPutAsync()
        {
            var id = Guid.NewGuid();

            _service.AlterarAsync(id).TaskThrowsException();

            var result = _controller.PutAsync(_service, id);

            await _service.Received().AlterarAsync(id);

            Assert.Null(result.Result);
        }
    }
}
