using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Candidato;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class CandidatoApplicationService : ICandidatoApplicationService
    {
        private readonly ICandidatoDomainService _domainService;

        public CandidatoApplicationService(ICandidatoDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<bool> AlterarAsync(ManterCandidatoModel model)
        {
            var entity = await _domainService.GetByIdAsync(model.Id.Value);
            entity.Alterar(model.AnamneseId, model.CargoId, model.DataNascimento, model.DocumentoId,
                model.Email, model.EmpresaId, model.Nome, model.OrgaoEmissor, model.RG, model.UF);

            return await _domainService.UpdateAsync(entity);
        }

        public async Task<bool> CriarAsync(ManterCandidatoModel model)
        {
            var entity = new Candidato(model.CargoId, model.DataNascimento, model.Email, model.EmpresaId, model.Nome);
            entity.SetRG(model.RG, model.UF, model.OrgaoEmissor);

            return await _domainService.InsertAsync(entity);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return await _domainService.DeleteAsync(entity);
        }

        public async Task<IEnumerable<CandidatoModel>> ObterAsync(string nome, string rg, string email)
        {
            var entities = await _domainService.GetAllAsync(nome, rg, email);
            return ConvertToDto(entities);
        }

        public async Task<CandidatoModel> ObterPorIdAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return ConvertToDto(entity);
        }

        #region private

        private static List<CandidatoModel> ConvertToDto(IEnumerable<Candidato> entities)
        {
            var models = new List<CandidatoModel>();
            foreach (var e in entities)
            {
                models.Add(ConvertToDto(e));
            }
            return models;
        }

        private static CandidatoModel ConvertToDto(Candidato e)
        {
            return new CandidatoModel
            {
                Id = e.Id,
                AnamneseId = e.AnamneseId,
                CargoId = e.CargoId,
                DataNascimento = e.DataNascimento,
                DocumentoId = e.DocumentoId,
                Email = e.Email,
                EmpresaId = e.EmpresaId,
                Nome = e.Nome,
                OrgaoEmissor = e.OrgaoEmissor,
                RG = e.RG,
                UF = e.UF
            };
        }

        #endregion private
    }
}