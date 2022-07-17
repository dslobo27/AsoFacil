using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsoFacil.InfraStructure.Migrations
{
    public partial class asofacilcargainicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    varchar = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    CRM = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusAgendamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAgendamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusSolicitacoesAtivacaoEmpresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusSolicitacoesAtivacaoEmpresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    MenuSistema = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PossuiDoencaCoracao = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaProblemaPsiquiatrico = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaQuadroAnsiedade = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaQuadroDepressao = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaQuadroInsonia = table.Column<bool>(type: "bit", nullable: false),
                    PossuiHepatite = table.Column<bool>(type: "bit", nullable: false),
                    PossuiHernia = table.Column<bool>(type: "bit", nullable: false),
                    PossuiDoencaRins = table.Column<bool>(type: "bit", nullable: false),
                    PossuiDiabetes = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaDoresCostas = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaDoresOmbros = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaDoresPunhos = table.Column<bool>(type: "bit", nullable: false),
                    ApresentaDoresMaos = table.Column<bool>(type: "bit", nullable: false),
                    DiagnosticoCancer = table.Column<bool>(type: "bit", nullable: false),
                    Fuma = table.Column<bool>(type: "bit", nullable: false),
                    QuantosCigarrosDia = table.Column<int>(type: "int", nullable: false),
                    Bebe = table.Column<bool>(type: "bit", nullable: false),
                    PraticaAtividadeFisica = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoAtividadeFisica = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    SofreuAlgumaFratura = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoFaturaSofrida = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    EsteveInternado = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoMotivoInternacao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PossuiProblemaAuditivo = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoProblemaAuditivo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PossuiProblemaVisao = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoProblemaVisao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    FezAlgumaCirurgia = table.Column<bool>(type: "bit", nullable: false),
                    JaSofreuAcidenteTrabalho = table.Column<bool>(type: "bit", nullable: false),
                    JaEsteveAfastadoMaisQuinzeDias = table.Column<bool>(type: "bit", nullable: false),
                    MotivoAfastadoMaisQuinzeDias = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    RecebeIndenizacaoAcidenteOuDoencaOcupacional = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoMotivoRecebeIndenizacao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    JaPassouReabilitacaoProfissionalINSS = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoMotivoReabilitacaoProfissionalINSS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PortadorDeficienciaFisica = table.Column<bool>(type: "bit", nullable: false),
                    PortadorDeficienciaAuditiva = table.Column<bool>(type: "bit", nullable: false),
                    PortadorDeficienciaVisual = table.Column<bool>(type: "bit", nullable: false),
                    PortadorDeficienciaMental = table.Column<bool>(type: "bit", nullable: false),
                    PortadorDeficienciaMultipla = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apto = table.Column<bool>(type: "bit", nullable: false),
                    MotivoInapto = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true),
                    Local = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamneses_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacoesAtivacaoEmpresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusSolicitacaoAtivacaoEmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacoesAtivacaoEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacoesAtivacaoEmpresas_StatusSolicitacoesAtivacaoEmpresas_StatusSolicitacaoAtivacaoEmpresaId",
                        column: x => x.StatusSolicitacaoAtivacaoEmpresaId,
                        principalTable: "StatusSolicitacoesAtivacaoEmpresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true),
                    RazaoSocial = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    SolicitacaoAtivacaoEmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_SolicitacoesAtivacaoEmpresas_SolicitacaoAtivacaoEmpresaId",
                        column: x => x.SolicitacaoAtivacaoEmpresaId,
                        principalTable: "SolicitacoesAtivacaoEmpresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    RG = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    OrgaoEmissor = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnamneseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Anamneses_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidatos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidatos_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidatos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Senha = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    TipoUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TiposUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusAgendamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_StatusAgendamentos_StatusAgendamentoId",
                        column: x => x.StatusAgendamentoId,
                        principalTable: "StatusAgendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_CandidatoId",
                table: "Agendamentos",
                column: "CandidatoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EmpresaId",
                table: "Agendamentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_StatusAgendamentoId",
                table: "Agendamentos",
                column: "StatusAgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_MedicoId",
                table: "Anamneses",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_AnamneseId",
                table: "Candidatos",
                column: "AnamneseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_CargoId",
                table: "Candidatos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_DocumentoId",
                table: "Candidatos",
                column: "DocumentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_EmpresaId",
                table: "Candidatos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SolicitacaoAtivacaoEmpresaId",
                table: "Empresas",
                column: "SolicitacaoAtivacaoEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesAtivacaoEmpresas_StatusSolicitacaoAtivacaoEmpresaId",
                table: "SolicitacoesAtivacaoEmpresas",
                column: "StatusSolicitacaoAtivacaoEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "StatusAgendamentos");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");

            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "SolicitacoesAtivacaoEmpresas");

            migrationBuilder.DropTable(
                name: "StatusSolicitacoesAtivacaoEmpresas");
        }
    }
}
