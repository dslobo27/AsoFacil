using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.StatusAgendamento;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class StatusAgendamentoApplicationService : IStatusAgendamentoApplicationService
    {
        private readonly IStatusAgendamentoDomainService _statusAgendamentoDomainService;

        public StatusAgendamentoApplicationService(IStatusAgendamentoDomainService statusAgendamentoDomainService)
        {
            _statusAgendamentoDomainService = statusAgendamentoDomainService;
        }

        public async Task<bool> AlterarAsync(ManterStatusAgendamentoModel model)
        {
            var statusAgendamento = await _statusAgendamentoDomainService.GetByIdAsync(model.Id.Value);
            statusAgendamento.Alterar(model.Descricao);

            return await _statusAgendamentoDomainService.UpdateAsync(statusAgendamento);
        }

        public async Task<bool> CriarAsync(ManterStatusAgendamentoModel model)
        {
            var statusAgendamento = new StatusAgendamento(model.Descricao);
            return await _statusAgendamentoDomainService.InsertAsync(statusAgendamento);
        }

        public async Task<bool> ExcluirAsync(Guid statusAgendamentoId)
        {
            var statusAgendamento = await _statusAgendamentoDomainService.GetByIdAsync(statusAgendamentoId);
            return await _statusAgendamentoDomainService.DeleteAsync(statusAgendamento);
        }

        public async Task<IEnumerable<StatusAgendamentoModel>> ObterAsync(string descricao)
        {
            var statusAgendamentos = await _statusAgendamentoDomainService.GetAllAsync(descricao);
            return ConvertToDto(statusAgendamentos);
        }

        public async Task<StatusAgendamentoModel> ObterPorIdAsync(Guid statusAgendamentoId)
        {
            var statusAgendamento = await _statusAgendamentoDomainService.GetByIdAsync(statusAgendamentoId);
            return ConvertToDto(statusAgendamento);
        }

        #region private

        private static List<StatusAgendamentoModel> ConvertToDto(IEnumerable<StatusAgendamento> statusAgendamentos)
        {
            var statusAgendamentosModels = new List<StatusAgendamentoModel>();
            foreach (var s in statusAgendamentos)
            {
                statusAgendamentosModels.Add(ConvertToDto(s));
            }
            return statusAgendamentosModels;
        }

        private static StatusAgendamentoModel ConvertToDto(StatusAgendamento s)
        {
            return new StatusAgendamentoModel
            {
                Id = s.Id,
                Descricao = s.Descricao
            };
        }

        #endregion private
    }
}