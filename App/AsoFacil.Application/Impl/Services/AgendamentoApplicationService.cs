using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Agendamento;
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
            var entity = new Agendamento(model.CandidatoId, model.DataHora);            
            return await _domainService.InsertAsync(entity);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return await _domainService.DeleteAsync(entity);
        }

        public async Task<IEnumerable<AgendamentoModel>> ObterAsync(string nome, string rg, DateTime? dataInicio, DateTime? dataFim)
        {
            var entities = await _domainService.GetAllAsync(nome, rg, dataInicio, dataFim);
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
                StatusAgendamentoId = e.StatusAgendamentoId
            };
        }

        #endregion private
    }
}
