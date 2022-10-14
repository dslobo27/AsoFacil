using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Agendamento;
using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using AsoFacil.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace AsoFacil.Tests
{
    public class AgendamentosControllerTest
    {
        private readonly ClaimsPrincipal _user;
        private readonly AgendamentosController _controller;
        private readonly IAgendamentoApplicationService _service;
        
        public AgendamentosControllerTest()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("EMPRESA_ID", Guid.NewGuid().ToString()),
                new Claim("COD_TIPO_USUARIO", "ASOFACIL_ADMIN")
            }, "mock"));

            _controller = Substitute.For<AgendamentosController>();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = _user };

            _service = Substitute.For<IAgendamentoApplicationService>();
        }

        [Fact]
        public async Task ShouldGetAsync()
        {   
            var nome = string.Empty;
            var rg = string.Empty;
            var dtInicio = new DateTime(2022, 01, 01).ToString("dd/MM/yyyy");
            var dtFim = new DateTime(2022, 12, 31).ToString("dd/MM/yyyy");

            _service.ObterAsync(Arg.Any<string>(), Arg.Any<string>(), 
                Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<Guid>())
                .ReturnsForAnyArgs(new List<AgendamentoModel> {
                    new AgendamentoModel()
                });

            var result = _controller.GetAsync(_service, nome, rg, dtInicio, dtFim);

            await _service.Received().ObterAsync(Arg.Any<string>(), Arg.Any<string>(), 
                Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<Guid>());

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenGetAsync()
        {
            var nome = string.Empty;
            var rg = string.Empty;
            var dtInicio = new DateTime(2022, 01, 01).ToString("dd/MM/yyyy");
            var dtFim = new DateTime(2022, 12, 31).ToString("dd/MM/yyyy");

            _service.ObterAsync(Arg.Any<string>(), Arg.Any<string>(),
                Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<Guid>())
                .TaskThrowsException();

            var result = _controller.GetAsync(_service, nome, rg, dtInicio, dtFim);

            await _service.Received().ObterAsync(Arg.Any<string>(), Arg.Any<string>(),
                Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<Guid>());

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldGetByIdAsync()
        {
            var id = Guid.NewGuid();

            _service.ObterPorIdAsync(Arg.Any<Guid>())
                .ReturnsForAnyArgs(new AgendamentoModel());

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
            var model = new ManterAgendamentoModel
            {
                Id = Guid.NewGuid(),
                CandidatoId = Guid.NewGuid(),
                EmpresaId = Guid.NewGuid(),
                StatusAgendamentoId = Guid.NewGuid(),
                DataHora = new DateTime(2022, 10, 13)
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
            var model = new ManterAgendamentoModel
            {
                Id = Guid.NewGuid(),
                CandidatoId = Guid.NewGuid(),
                EmpresaId = Guid.NewGuid(),
                StatusAgendamentoId = Guid.NewGuid(),
                DataHora = new DateTime(2022, 10, 13)
            };

            _service.CriarAsync(model).TaskThrowsException();

            var result = _controller.PostAsync(_service, model);

            await _service.Received().CriarAsync(model);

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldPutAsync()
        {
            var model = new ManterAgendamentoModel
            {
                Id = Guid.NewGuid(),
                CandidatoId = Guid.NewGuid(),
                EmpresaId = Guid.NewGuid(),
                StatusAgendamentoId = Guid.NewGuid(),
                DataHora = new DateTime(2022, 10, 13)
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
            var model = new ManterAgendamentoModel
            {
                Id = Guid.NewGuid(),
                CandidatoId = Guid.NewGuid(),
                EmpresaId = Guid.NewGuid(),
                StatusAgendamentoId = Guid.NewGuid(),
                DataHora = new DateTime(2022, 10, 13)
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