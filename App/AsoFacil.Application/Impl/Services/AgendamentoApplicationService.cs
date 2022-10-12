using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Agendamento;
using AsoFacil.Application.Models.Candidato;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.StatusAgendamento;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class AgendamentoApplicationService : IAgendamentoApplicationService
    {
        private readonly IAgendamentoDomainService _domainService;

        public AgendamentoApplicationService(IAgendamentoDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<bool> AlterarAsync(ManterAgendamentoModel model)
        {
            var entity = await _domainService.GetByIdAsync(model.Id.Value);
            entity.Alterar(model.CandidatoId, model.StatusAgendamentoId, model.DataHora);

            return await _domainService.UpdateAsync(entity);
        }

        public async Task<bool> CriarAsync(ManterAgendamentoModel model)
        {
            var entity = new Agendamento(model.Id.GetValueOrDefault(), model.CandidatoId, model.DataHora, model.StatusAgendamentoId.GetValueOrDefault());            
            return await _domainService.InsertAsync(entity);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return await _domainService.DeleteAsync(entity);
        }

        public async Task<IEnumerable<AgendamentoModel>> ObterAsync(string nome, string rg, DateTime? dataInicio, DateTime? dataFim, Guid empresaId)
        {
            var entities = await _domainService.GetAllAsync(nome, rg, dataInicio, dataFim, empresaId);
            return ConvertToDto(entities);
        }

        public async Task<AgendamentoModel> ObterPorIdAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return ConvertToDto(entity);
        }

        #region private

        private static List<AgendamentoModel> ConvertToDto(IEnumerable<Agendamento> entities)
        {
            var models = new List<AgendamentoModel>();
            foreach (var e in entities)
            {
                models.Add(ConvertToDto(e));
            }
            return models;
        }

        private static AgendamentoModel ConvertToDto(Agendamento e)
        {
            return new AgendamentoModel
            {
                Id = e.Id,
                CandidatoId = e.CandidatoId,
                DataHora = e.DataHora,
                StatusAgendamentoId = e.StatusAgendamentoId,
                EmpresaId = e.EmpresaId,
                Candidato = new CandidatoModel
                {
                    Id = e.Id,
                    AnamneseId = e.Candidato.AnamneseId.GetValueOrDefault(),
                    CargoId = e.Candidato.CargoId,
                    DataNascimento = e.Candidato.DataNascimento,
                    DocumentoId = e.Candidato.DocumentoId.GetValueOrDefault(),
                    Email = e.Candidato.Email,
                    EmpresaId = e.Candidato.EmpresaId,
                    Nome = e.Candidato.Nome,
                    OrgaoEmissor = e.Candidato.OrgaoEmissor,
                    RG = e.Candidato.RG,
                    UF = e.Candidato.UF
                },
                StatusAgendamento = new StatusAgendamentoModel
                {
                    Id = e.StatusAgendamento.Id,
                    Descricao = e.StatusAgendamento.Descricao
                },
                Empresa = new EmpresaModel
                {
                    Id = e.Empresa.Id,
                    CNPJ = e.Empresa.CNPJ,
                    RazaoSocial = e.Empresa.RazaoSocial,
                    Email = e.Empresa.Email,
                    Ativa = e.Empresa.Ativa,
                    SolicitacaoAtivacaoEmpresaId = e.Empresa.SolicitacaoAtivacaoEmpresaId,
                    FlagClinica = e.Empresa.FlagClinica
                }
            };
        }

        #endregion private
    }
}
