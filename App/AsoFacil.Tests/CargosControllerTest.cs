﻿using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Cargo;
using AsoFacil.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace AsoFacil.Tests
{
    public class CargosControllerTest
    {
        private readonly ClaimsPrincipal _user;
        private readonly CargosController _controller;
        private readonly ICargoApplicationService _service;

        public CargosControllerTest()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("EMPRESA_ID", Guid.NewGuid().ToString()),
                new Claim("COD_TIPO_USUARIO", "ASOFACIL_ADMIN")
            }, "mock"));

            _controller = Substitute.For<CargosController>();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = _user };

            _service = Substitute.For<ICargoApplicationService>();
        }

        [Fact]
        public async Task ShouldGetAsync()
        {
            var descricao = string.Empty;

            _service.ObterAsync(Arg.Any<string>())
                .ReturnsForAnyArgs(new List<CargoModel> {
                    new CargoModel()
                });

            var result = _controller.GetAsync(_service, descricao);

            await _service.Received().ObterAsync(Arg.Any<string>());

            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ShouldRaiseExceptionWhenGetAsync()
        {
            var descricao = string.Empty;

            _service.ObterAsync(Arg.Any<string>()).TaskThrowsException();

            var result = _controller.GetAsync(_service, descricao);

            await _service.Received().ObterAsync(Arg.Any<string>());

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldGetByIdAsync()
        {
            var id = Guid.NewGuid();

            _service.ObterPorIdAsync(Arg.Any<Guid>())
                .ReturnsForAnyArgs(new CargoModel());

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
            var model = new ManterCargoModel
            {
                Id = Guid.NewGuid(),
                Descricao = "descricao"
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
            var model = new ManterCargoModel
            {
                Id = Guid.NewGuid(),
                Descricao = "descricao"
            };

            _service.CriarAsync(model).TaskThrowsException();

            var result = _controller.PostAsync(_service, model);

            await _service.Received().CriarAsync(model);

            Assert.Null(result.Result);
        }

        [Fact]
        public async Task ShouldPutAsync()
        {
            var model = new ManterCargoModel
            {
                Id = Guid.NewGuid(),
                Descricao = "descricao"
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
            var model = new ManterCargoModel
            {
                Id = Guid.NewGuid(),
                Descricao = "descricao"
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