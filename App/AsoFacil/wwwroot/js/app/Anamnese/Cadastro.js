$(document).ready(function () {
    let preloader = $('#preloader');
    $('#btn-cadastro').click(function (e) {
        e.preventDefault();
        var formValid = $('#form-cadastro').valid();
        if (!formValid) {
            return false;
        }

        preloader.show();

        let model = {
            CandidatoId: $('#id').val(),
            PossuiDoencaCoracao: $('#PossuiDoencaCoracao').is(':checked'),
            ApresentaProblemaPsiquiatrico: $('#ApresentaProblemaPsiquiatrico').is(':checked'),
            ApresentaQuadroAnsiedade: $('#ApresentaQuadroAnsiedade').is(':checked'),
            ApresentaQuadroDepressao: $('#ApresentaQuadroDepressao').is(':checked'),
            ApresentaQuadroInsonia: $('#ApresentaQuadroInsonia').is(':checked'),
            PossuiHepatite: $('#PossuiHepatite').is(':checked'),
            PossuiHernia: $('#PossuiHernia').is(':checked'),
            PossuiDoencaRins: $('#PossuiDoencaRins').is(':checked'),
            PossuiDiabetes: $('#PossuiDiabetes').is(':checked'),
            ApresentaDoresCostas: $('#ApresentaDoresCostas').is(':checked'),
            ApresentaDoresOmbros: $('#ApresentaDoresOmbros').is(':checked'),
            ApresentaDoresPunhos: $('#ApresentaDoresPunhos').is(':checked'),
            ApresentaDoresMaos: $('#ApresentaDoresMaos').is(':checked'),
            DiagnosticoCancer: $('#DiagnosticoCancer').is(':checked'),
            Fuma: $('#Fuma').is(':checked'),
            QuantosCigarrosDia: $('#QuantosCigarrosDia').val(),
            Bebe: $('#Bebe').is(':checked'),
            PraticaAtividadeFisica: $('#PraticaAtividadeFisica').is(':checked'),
            DescricaoAtividadeFisica: $('#DescricaoAtividadeFisica').val(),
            SofreuAlgumaFratura: $('#SofreuAlgumaFratura').is(':checked'),
            DescricaoFaturaSofrida: $('#DescricaoFaturaSofrida').val(),
            EsteveInternado: $('#EsteveInternado').is(':checked'),
            DescricaoMotivoInternacao: $('#DescricaoMotivoInternacao').val(),
            PossuiProblemaAuditivo: $('#PossuiProblemaAuditivo').is(':checked'),
            DescricaoProblemaAuditivo: $('#DescricaoProblemaAuditivo').val(),
            PossuiProblemaVisao: $('#PossuiProblemaVisao').is(':checked'),
            DescricaoProblemaVisao: $('#DescricaoProblemaVisao').val(),
            FezAlgumaCirurgia: $('#FezAlgumaCirurgia').is(':checked'),
            JaSofreuAcidenteTrabalho: $('#JaSofreuAcidenteTrabalho').is(':checked'),
            JaEsteveAfastadoMaisQuinzeDias: $('#JaEsteveAfastadoMaisQuinzeDias').is(':checked'),
            MotivoAfastadoMaisQuinzeDias: $('#MotivoAfastadoMaisQuinzeDias').val(),
            RecebeIndenizacaoAcidenteOuDoencaOcupacional: $('#RecebeIndenizacaoAcidenteOuDoencaOcupacional').is(':checked'),
            DescricaoMotivoRecebeIndenizacao: $('#DescricaoMotivoRecebeIndenizacao').val(),
            JaPassouReabilitacaoProfissionalINSS: $('#JaPassouReabilitacaoProfissionalINSS').is(':checked'),
            DescricaoMotivoReabilitacaoProfissionalINSS: $('#DescricaoMotivoReabilitacaoProfissionalINSS').val(),
            PortadorDeficienciaFisica: $('#PortadorDeficienciaFisica').is(':checked'),
            PortadorDeficienciaAuditiva: $('#PortadorDeficienciaAuditiva').is(':checked'),
            PortadorDeficienciaVisual: $('#PortadorDeficienciaVisual').is(':checked'),
            PortadorDeficienciaMental: $('#PortadorDeficienciaMental').is(':checked'),
            PortadorDeficienciaMultipla: $('#PortadorDeficienciaMultipla').is(':checked')
        };

        $.ajax({
            type: 'POST',
            url: '/anamnese/postasync',
            data: JSON.stringify(model),
            async: true,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (taskResult) {
                hideLoading();
                if (taskResult.isSuccess) {
                    alertify.success('Anamnese cadastrada com sucesso!');
                    window.location.href = '/Home';
                    return;
                }
                alertify.error(taskResult.errors.join());
            },
            error: function (e) {
                console.error(e);
            }
        });
    });
});