using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Candidato;
using AsoFacil.Application.Models.Cargo;
using AsoFacil.Application.Models.Empresa;
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

        public async Task<bool> AlterarAnamneseAsync(AnamneseModel model)
        {
            var entity = await _domainService.GetAnamneseByIdAsync(model.Id);
            entity.PossuiDoencaCoracao = model.PossuiDoencaCoracao;
            entity.ApresentaProblemaPsiquiatrico = model.ApresentaProblemaPsiquiatrico;
            entity.ApresentaQuadroAnsiedade = model.ApresentaQuadroAnsiedade;
            entity.ApresentaQuadroDepressao = model.ApresentaQuadroDepressao;
            entity.ApresentaQuadroInsonia = model.ApresentaQuadroInsonia;
            entity.PossuiHepatite = model.PossuiHepatite;
            entity.PossuiHernia = model.PossuiHernia;
            entity.PossuiDoencaRins = model.PossuiDoencaRins;
            entity.PossuiDiabetes = model.PossuiDiabetes;
            entity.ApresentaDoresCostas = model.ApresentaDoresCostas;
            entity.ApresentaDoresOmbros = model.ApresentaDoresOmbros;
            entity.ApresentaDoresPunhos = model.ApresentaDoresPunhos;
            entity.ApresentaDoresMaos = model.ApresentaDoresMaos;
            entity.DiagnosticoCancer = model.DiagnosticoCancer;
            entity.Fuma = model.Fuma;
            entity.QuantosCigarrosDia = model.QuantosCigarrosDia;
            entity.Bebe = model.Bebe;
            entity.PraticaAtividadeFisica = model.PraticaAtividadeFisica;
            entity.DescricaoAtividadeFisica = model.DescricaoAtividadeFisica;
            entity.SofreuAlgumaFratura = model.SofreuAlgumaFratura;
            entity.DescricaoFaturaSofrida = model.DescricaoFaturaSofrida;
            entity.EsteveInternado = model.EsteveInternado;
            entity.DescricaoMotivoInternacao = model.DescricaoMotivoInternacao;
            entity.PossuiProblemaAuditivo = model.PossuiProblemaAuditivo;
            entity.DescricaoProblemaAuditivo = model.DescricaoProblemaAuditivo;
            entity.PossuiProblemaVisao = model.PossuiProblemaVisao;
            entity.DescricaoProblemaVisao = model.DescricaoProblemaVisao;
            entity.FezAlgumaCirurgia = model.FezAlgumaCirurgia;
            entity.JaSofreuAcidenteTrabalho = model.JaSofreuAcidenteTrabalho;
            entity.JaEsteveAfastadoMaisQuinzeDias = model.JaEsteveAfastadoMaisQuinzeDias;
            entity.MotivoAfastadoMaisQuinzeDias = model.MotivoAfastadoMaisQuinzeDias;
            entity.RecebeIndenizacaoAcidenteOuDoencaOcupacional = model.RecebeIndenizacaoAcidenteOuDoencaOcupacional;
            entity.DescricaoMotivoRecebeIndenizacao = model.DescricaoMotivoRecebeIndenizacao;
            entity.JaPassouReabilitacaoProfissionalINSS = model.JaPassouReabilitacaoProfissionalINSS;
            entity.DescricaoMotivoReabilitacaoProfissionalINSS = model.DescricaoMotivoReabilitacaoProfissionalINSS;
            entity.PortadorDeficienciaFisica = model.PortadorDeficienciaFisica;
            entity.PortadorDeficienciaAuditiva = model.PortadorDeficienciaAuditiva;
            entity.PortadorDeficienciaVisual = model.PortadorDeficienciaVisual;
            entity.PortadorDeficienciaMental = model.PortadorDeficienciaMental;
            entity.PortadorDeficienciaMultipla = model.PortadorDeficienciaMultipla;
            entity.MedicoId = model.MedicoId.GetValueOrDefault();
            entity.Local = model.Local;
            entity.Data = model.Data.GetValueOrDefault();
            entity.Apto = model.Apto;
            entity.MotivoInapto = model.MotivoInapto;

            return await _domainService.UpdateAnamneseAsync(entity);
        }

        public async Task<bool> CriarAsync(ManterCandidatoModel model)
        {
            var entity = new Candidato(model.CargoId, model.DataNascimento, model.Email, model.EmpresaId, model.Nome);
            entity.SetRG(model.RG, model.UF, model.OrgaoEmissor);

            return await _domainService.InsertAsync(entity);
        }

        public async Task<bool> CriarAnamneseAsync(AnamneseModel model)
        {
            var entity = new Anamnese();
            entity.Id = model.Id;
            entity.PossuiDoencaCoracao = model.PossuiDoencaCoracao;
            entity.ApresentaProblemaPsiquiatrico = model.ApresentaProblemaPsiquiatrico;
            entity.ApresentaQuadroAnsiedade = model.ApresentaQuadroAnsiedade;
            entity.ApresentaQuadroDepressao = model.ApresentaQuadroDepressao;
            entity.ApresentaQuadroInsonia = model.ApresentaQuadroInsonia;
            entity.PossuiHepatite = model.PossuiHepatite;
            entity.PossuiHernia = model.PossuiHernia;
            entity.PossuiDoencaRins = model.PossuiDoencaRins;
            entity.PossuiDiabetes = model.PossuiDiabetes;
            entity.ApresentaDoresCostas = model.ApresentaDoresCostas;
            entity.ApresentaDoresOmbros = model.ApresentaDoresOmbros;
            entity.ApresentaDoresPunhos = model.ApresentaDoresPunhos;
            entity.ApresentaDoresMaos = model.ApresentaDoresMaos;
            entity.DiagnosticoCancer = model.DiagnosticoCancer;
            entity.Fuma = model.Fuma;
            entity.QuantosCigarrosDia = model.QuantosCigarrosDia;
            entity.Bebe = model.Bebe;
            entity.PraticaAtividadeFisica = model.PraticaAtividadeFisica;
            entity.DescricaoAtividadeFisica = model.DescricaoAtividadeFisica;
            entity.SofreuAlgumaFratura = model.SofreuAlgumaFratura;
            entity.DescricaoFaturaSofrida = model.DescricaoFaturaSofrida;
            entity.EsteveInternado = model.EsteveInternado;
            entity.DescricaoMotivoInternacao = model.DescricaoMotivoInternacao;
            entity.PossuiProblemaAuditivo = model.PossuiProblemaAuditivo;
            entity.DescricaoProblemaAuditivo = model.DescricaoProblemaAuditivo;
            entity.PossuiProblemaVisao = model.PossuiProblemaVisao;
            entity.DescricaoProblemaVisao = model.DescricaoProblemaVisao;
            entity.FezAlgumaCirurgia = model.FezAlgumaCirurgia;
            entity.JaSofreuAcidenteTrabalho = model.JaSofreuAcidenteTrabalho;
            entity.JaEsteveAfastadoMaisQuinzeDias = model.JaEsteveAfastadoMaisQuinzeDias;
            entity.MotivoAfastadoMaisQuinzeDias = model.MotivoAfastadoMaisQuinzeDias;
            entity.RecebeIndenizacaoAcidenteOuDoencaOcupacional = model.RecebeIndenizacaoAcidenteOuDoencaOcupacional;
            entity.DescricaoMotivoRecebeIndenizacao = model.DescricaoMotivoRecebeIndenizacao;
            entity.JaPassouReabilitacaoProfissionalINSS = model.JaPassouReabilitacaoProfissionalINSS;
            entity.DescricaoMotivoReabilitacaoProfissionalINSS = model.DescricaoMotivoReabilitacaoProfissionalINSS;
            entity.PortadorDeficienciaFisica = model.PortadorDeficienciaFisica;
            entity.PortadorDeficienciaAuditiva = model.PortadorDeficienciaAuditiva;
            entity.PortadorDeficienciaVisual = model.PortadorDeficienciaVisual;
            entity.PortadorDeficienciaMental = model.PortadorDeficienciaMental;
            entity.PortadorDeficienciaMultipla = model.PortadorDeficienciaMultipla;

            return await _domainService.InsertAnamneseAsync(entity, model.CandidatoId.GetValueOrDefault());
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

        public async Task<AnamneseModel> ObterAnamnesePorCandidatoIdAsync(Guid id)
        {
            var entity = await _domainService.GetAnamneseByCandidatoIdAsync(id);
            return ConvertAnamneseToDto(entity);
        }

        public async Task<ASOModel> ObterASOByCandidatoAnamneseIdAsync(Guid candidatoId, Guid anamneseId)
        {
            var anamnese = await _domainService.GetAnamneseByCandidatoIdAsync(candidatoId);
            var candidato = await _domainService.GetByIdAsync(candidatoId);

            return ConvertASOToDto(anamnese, candidato);
        }

        #region private

        private static ASOModel ConvertASOToDto(Anamnese anamnese, Candidato candidato)
        {
            return new ASOModel
            {
                Nome = candidato.Nome.ToUpper(),
                Documento = $"{Convert.ToUInt64(candidato.RG).ToString(@"00\.000\.000\-0")} - {candidato.OrgaoEmissor.ToUpper()}/{candidato.UF.ToUpper()}",
                Cargo = candidato.Cargo.Descricao,
                Email = candidato.Email,
                DataNascimento = candidato.DataNascimento.ToString("dd/MM/yyyy"),
                CNPJ = Convert.ToUInt64(candidato.Empresa.CNPJ).ToString(@"000\.000\.000\-00"),
                RazaoSocial = candidato.Empresa.RazaoSocial.ToUpper(),
                Medico = anamnese.Medico.Nome.ToUpper(),
                MotivoInapto = anamnese.MotivoInapto.ToUpper(),
                Data = anamnese.Data.ToString("dd/MM/yyyy"),
                Status = anamnese.Apto ? "APTO" : "INAPTO",
                Local = ObterLocal(anamnese.Local).ToUpper()
            };
        }

        private static string ObterLocal(string sigla)
        {
            var dic = new Dictionary<string, string>();

            dic.Add("AC", "Acre");
            dic.Add("AL", "Alagoas");
            dic.Add("AP", "Amapá");
            dic.Add("AM", "Amazonas");
            dic.Add("BA", "Bahia");
            dic.Add("CE", "Ceará");
            dic.Add("DF", "Distrito Federal");
            dic.Add("ES", "Espírito Santo");
            dic.Add("GO", "Goiás");
            dic.Add("MA", "Maranhão");
            dic.Add("MT", "Mato Grosso");
            dic.Add("MS", "Mato Grosso do Sul");
            dic.Add("MG", "Minas Gerais");
            dic.Add("PA", "Pará");
            dic.Add("PB", "Paraíba");
            dic.Add("PR", "Paraná");
            dic.Add("PE", "Pernambuco");
            dic.Add("PI", "Piauí");
            dic.Add("RJ", "Rio de Janeiro");
            dic.Add("RN", "Rio Grande do Norte");
            dic.Add("RS", "Rio Grande do Sul");
            dic.Add("RO", "Rondônia");
            dic.Add("RR", "Roraima");
            dic.Add("SC", "Santa Catarina");
            dic.Add("SP", "São Paulo");
            dic.Add("SE", "Sergipe");
            dic.Add("TO", "Tocantins");

            return dic[sigla];
        }

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
                AnamneseId = e.AnamneseId.GetValueOrDefault(),
                CargoId = e.CargoId,
                DataNascimento = e.DataNascimento,
                DocumentoId = e.DocumentoId.GetValueOrDefault(),
                Email = e.Email,
                EmpresaId = e.EmpresaId,
                Nome = e.Nome,
                OrgaoEmissor = e.OrgaoEmissor,
                RG = e.RG,
                UF = e.UF,
                Cargo = new CargoModel
                {
                    Id = e.Cargo.Id,
                    Descricao = e.Cargo.Descricao
                },
                Empresa = new EmpresaModel
                {
                    Id = e.Empresa.Id,
                    CNPJ = e.Empresa.CNPJ,
                    Ativa = e.Empresa.Ativa,
                    Email = e.Empresa.Email,
                    FlagClinica = e.Empresa.FlagClinica,
                    RazaoSocial = e.Empresa.RazaoSocial,
                    SolicitacaoAtivacaoEmpresaId = e.Empresa.SolicitacaoAtivacaoEmpresaId
                },
                Anamnese = new AnamneseModel
                {
                    MedicoId = e.Anamnese?.Medico?.Id
                }
            };
        }

        private static AnamneseModel ConvertAnamneseToDto(Anamnese model)
        {
            var entity = new AnamneseModel();
            entity.CandidatoId = model.Candidato.Id;
            entity.Id = model.Id;
            entity.PossuiDoencaCoracao = model.PossuiDoencaCoracao;
            entity.ApresentaProblemaPsiquiatrico = model.ApresentaProblemaPsiquiatrico;
            entity.ApresentaQuadroAnsiedade = model.ApresentaQuadroAnsiedade;
            entity.ApresentaQuadroDepressao = model.ApresentaQuadroDepressao;
            entity.ApresentaQuadroInsonia = model.ApresentaQuadroInsonia;
            entity.PossuiHepatite = model.PossuiHepatite;
            entity.PossuiHernia = model.PossuiHernia;
            entity.PossuiDoencaRins = model.PossuiDoencaRins;
            entity.PossuiDiabetes = model.PossuiDiabetes;
            entity.ApresentaDoresCostas = model.ApresentaDoresCostas;
            entity.ApresentaDoresOmbros = model.ApresentaDoresOmbros;
            entity.ApresentaDoresPunhos = model.ApresentaDoresPunhos;
            entity.ApresentaDoresMaos = model.ApresentaDoresMaos;
            entity.DiagnosticoCancer = model.DiagnosticoCancer;
            entity.Fuma = model.Fuma;
            entity.QuantosCigarrosDia = model.QuantosCigarrosDia;
            entity.Bebe = model.Bebe;
            entity.PraticaAtividadeFisica = model.PraticaAtividadeFisica;
            entity.DescricaoAtividadeFisica = model.DescricaoAtividadeFisica;
            entity.SofreuAlgumaFratura = model.SofreuAlgumaFratura;
            entity.DescricaoFaturaSofrida = model.DescricaoFaturaSofrida;
            entity.EsteveInternado = model.EsteveInternado;
            entity.DescricaoMotivoInternacao = model.DescricaoMotivoInternacao;
            entity.PossuiProblemaAuditivo = model.PossuiProblemaAuditivo;
            entity.DescricaoProblemaAuditivo = model.DescricaoProblemaAuditivo;
            entity.PossuiProblemaVisao = model.PossuiProblemaVisao;
            entity.DescricaoProblemaVisao = model.DescricaoProblemaVisao;
            entity.FezAlgumaCirurgia = model.FezAlgumaCirurgia;
            entity.JaSofreuAcidenteTrabalho = model.JaSofreuAcidenteTrabalho;
            entity.JaEsteveAfastadoMaisQuinzeDias = model.JaEsteveAfastadoMaisQuinzeDias;
            entity.MotivoAfastadoMaisQuinzeDias = model.MotivoAfastadoMaisQuinzeDias;
            entity.RecebeIndenizacaoAcidenteOuDoencaOcupacional = model.RecebeIndenizacaoAcidenteOuDoencaOcupacional;
            entity.DescricaoMotivoRecebeIndenizacao = model.DescricaoMotivoRecebeIndenizacao;
            entity.JaPassouReabilitacaoProfissionalINSS = model.JaPassouReabilitacaoProfissionalINSS;
            entity.DescricaoMotivoReabilitacaoProfissionalINSS = model.DescricaoMotivoReabilitacaoProfissionalINSS;
            entity.PortadorDeficienciaFisica = model.PortadorDeficienciaFisica;
            entity.PortadorDeficienciaAuditiva = model.PortadorDeficienciaAuditiva;
            entity.PortadorDeficienciaVisual = model.PortadorDeficienciaVisual;
            entity.PortadorDeficienciaMental = model.PortadorDeficienciaMental;
            entity.PortadorDeficienciaMultipla = model.PortadorDeficienciaMultipla;
            entity.Apto = model.Apto;
            return entity;
        }

        #endregion private
    }
}