using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Medico;
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
    public class MedicosControllerTest
    {
        private readonly ClaimsPrincipal _user;
        private readonly MedicosController _controller;
        private readonly IMedicoApplicationService _service;

        public MedicosControllerTest()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("EMPRESA_ID", Guid.NewGuid().ToString()),
                new Claim("COD_TIPO_USUARIO", "ASOFACIL_ADMIN")
            }, "mock"));

            _controller = Substitute.For<MedicosController>();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = _user };

            _service = Substitute.For<IMedicoApplicationService>();
        }

        [Fact]
        public async Task ShouldGetAsync()
        {
            var crm = string.Empty;
            var nome = string.Empty;

            _service.ObterAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Guid>())
                .ReturnsForAnyArgs(new List<MedicoModel> {
                    new MedicoModel()
                });

            var result = _controller.GetAsync(_service, crm, nome);

            await _service.Received().ObterAsync(Arg.Any<string>(), Arg.Any<string>(), 
                Arg.Any<Guid>());

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenGetAsync()
        {
            var crm = string.Empty;
            var nome = string.Empty;

            _service.ObterAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Guid>())
                .TaskThrowsException();

            var result = _controller.GetAsync(_service, crm, nome);

            await _service.Received().ObterAsync(Arg.Any<string>(), Arg.Any<string>(), 
                Arg.Any<Guid>());

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldGetByIdAsync()
        {
            var id = Guid.NewGuid();

            _service.ObterPorIdAsync(Arg.Any<Guid>())
                .ReturnsForAnyArgs(new MedicoModel());

            var result = _controller.GetByIdAsync(_service, id);

            await _service.Received().ObterPorIdAsync(Arg.Any<Guid>());

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenGetByIdAsync()
        {
            var id = Guid.NewGuid();

            _service.ObterPorIdAsync(Arg.Any<Guid>()).TaskThrowsException();

            var result = _controller.GetByIdAsync(_service, id);

            await _service.Received().ObterPorIdAsync(Arg.Any<Guid>());

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldPostAsync()
        {
            var model = new ManterMedicoModel
            {
                Id = Guid.NewGuid(),
                CRM = "crm",
                Email = "xpto@teste.com",
                EmpresaId = Guid.NewGuid(),
                Nome = "nome",
                UsuarioId = Guid.NewGuid()
            };

            _service.CriarAsync(model).ReturnsForAnyArgs(true);

            var result = _controller.PostAsync(_service, model);

            await _service.Received().CriarAsync(model);

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenPostAsync()
        {
            var model = new ManterMedicoModel
            {
                Id = Guid.NewGuid(),
                CRM = "crm",
                Email = "xpto@teste.com",
                EmpresaId = Guid.NewGuid(),
                Nome = "nome",
                UsuarioId = Guid.NewGuid()
            };

            _service.CriarAsync(model).TaskThrowsException();

            var result = _controller.PostAsync(_service, model);

            await _service.Received().CriarAsync(model);

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldPutAsync()
        {
            var model = new ManterMedicoModel
            {
                Id = Guid.NewGuid(),
                CRM = "crm",
                Email = "xpto@teste.com",
                EmpresaId = Guid.NewGuid(),
                Nome = "nome",
                UsuarioId = Guid.NewGuid()
            };

            _service.AlterarAsync(model).ReturnsForAnyArgs(true);

            var result = _controller.PutAsync(_service, model);

            await _service.Received().AlterarAsync(model);

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenPutAsync()
        {
            var model = new ManterMedicoModel
            {
                Id = Guid.NewGuid(),
                CRM = "crm",
                Email = "xpto@teste.com",
                EmpresaId = Guid.NewGuid(),
                Nome = "nome",
                UsuarioId = Guid.NewGuid()
            };

            _service.AlterarAsync(model).TaskThrowsException();

            var result = _controller.PutAsync(_service, model);

            await _service.Received().AlterarAsync(model);

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldDeleteAsync()
        {
            var id = Guid.NewGuid();

            _service.ExcluirAsync(id).ReturnsForAnyArgs(true);

            var result = _controller.DeleteAsync(_service, id);

            await _service.Received().ExcluirAsync(id);

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenDeleteAsync()
        {
            var id = Guid.NewGuid();

            _service.ExcluirAsync(id).TaskThrowsException();

            var result = _controller.DeleteAsync(_service, id);

            await _service.Received().ExcluirAsync(id);

            Assert.Null(result.Result);
        }
    }
}
