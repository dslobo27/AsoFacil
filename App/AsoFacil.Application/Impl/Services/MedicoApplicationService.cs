﻿using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.Medico;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class MedicoApplicationService : IMedicoApplicationService
    {
        private readonly IMedicoDomainService _domainService;

        public MedicoApplicationService(IMedicoDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<bool> AlterarAsync(ManterMedicoModel model)
        {
            var entity = await _domainService.GetByIdAsync(model.Id.Value);
            entity.Alterar(model.CRM, model.Nome);

            return await _domainService.UpdateAsync(entity);
        }

        public async Task<bool> CriarAsync(ManterMedicoModel model)
        {
            var entity = new Medico(model.CRM, model.Nome, model.Email, model.UsuarioId, model.EmpresaId.GetValueOrDefault());
            return await _domainService.InsertAsync(entity);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return await _domainService.DeleteAsync(entity);
        }

        public async Task<IEnumerable<MedicoModel>> ObterAsync(string crm, string nome, Guid empresaId)
        {
            var entities = await _domainService.GetAllAsync(crm, nome, empresaId);
            return ConvertToDto(entities);
        }

        public async Task<MedicoModel> ObterPorIdAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return ConvertToDto(entity);
        }

        #region private

        private static List<MedicoModel> ConvertToDto(IEnumerable<Medico> entities)
        {
            var models = new List<MedicoModel>();
            foreach (var e in entities)
            {
                models.Add(ConvertToDto(e));
            }
            return models;
        }

        private static MedicoModel ConvertToDto(Medico e)
        {
            return new MedicoModel
            {
                Id = e.Id,
                CRM = e.CRM,
                Nome = e.Nome,
                UsuarioId = e.UsuarioId,
                Email = e.Email,
                Empresa = new EmpresaModel
                {
                    Id = e.Empresa.Id,
                    Ativa = e.Empresa.Ativa,
                    CNPJ = e.Empresa.CNPJ,
                    Email = e.Empresa.Email,
                    FlagClinica = e.Empresa.FlagClinica,
                    RazaoSocial = e.Empresa.RazaoSocial,
                    SolicitacaoAtivacaoEmpresaId = e.Empresa.SolicitacaoAtivacaoEmpresaId
                }
            };
        }

        #endregion private
    }
}