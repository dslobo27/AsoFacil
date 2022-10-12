$(document).ready(function () {
    $.get("/dashboard/totalizadores/", function (data) {
        $("#total-empresas").html(data.totalEmpresas);
        $("#total-candidatos").html(data.totalCandidatos);
        $("#total-agendamentos").html(data.totalAgendamentos);
        $("#total-solicitacoes").html(data.totalSolicitacoes);
    });
});