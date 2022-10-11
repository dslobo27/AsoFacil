$(document).ready(function () {
    var empresaSelecionada = '';
    var cargoSelecionado = '';
    var medicoSelecionado = '';

    var oTable = $("#table-candidatos").DataTable({
        pagingType: 'full_numbers',
        pageLength: 10,
        processing: true,
        searching: false,
        language: {
            emptyTable: 'Nenhum registro encontrado',
            info: '_TOTAL_ registro(s)',
            infoEmpty: '0 registros',
            infoFiltered: '(Filtrados de _MAX_ registros)',
            infoPostFix: '',
            loadingRecords: 'Carregando...',
            processing: 'Processando...',
            zeroRecords: 'Nenhum registro encontrado',
            search: 'Pesquisar',
            paginate: {
                next: '>',
                previous: '<',
                first: '<<',
                last: '>>',
            },
            aria: {
                sortAscending: ': Ordenar',
                sortDescending: ': Ordenar',
            },
        },
        lengthChange: false,
        responsive: true,
        ajax: {
            url: '/candidato/getasync',
            data: function (d) {
                d.nome = $('#filtro-nome').val();
                d.rg = $('#filtro-rg').val();
                d.email = $('#filtro-email').val();
            },
            dataSrc: '',
            type: "GET",
            async: true,
            dataType: "json"
        },
        columns: [
            {
                orderable: false,
                data: "id",
                render: function (data, type, full) {
                    return '<a title="Editar" class="bi bi-pencil-square btn-editar text-dark" data-empresaId=' + full.empresa?.id + ' data-cargoId=' + full.cargo?.id + ' data-id=' + data + ' href=""></a>';
                }
            },
            { data: "nome", "autowidth": true },
            { data: "rg", "autowidth": true },
            { data: "email", "autowidth": true },
            {
                orderable: false,
                data: "id",
                render: function (data, type, full) {
                    if (full.anamnese?.medicoId != null && full.anamnese?.medicoId != '00000000-0000-0000-0000-000000000000' && full.anamnese?.medicoId != undefined)
                        return '<a title="Baixar ASO" class="bi bi-file-earmark-pdf btn-baixar-aso text-dark" data-anamneseId=' + full.anamneseId + ' data-candidatoId=' + data + ' data-id=' + full.anamnese?.medicoId + ' href=""></a>';

                    return '';
                }
            },
            {
                orderable: false,
                data: "id",
                render: function (data, type, full) {
                    if (full.anamneseId != null && full.anamneseId != '00000000-0000-0000-0000-000000000000' && full.anamneseId != undefined)
                        return '<a title="Editar Anamnese" class="bi bi-clipboard-check btn-editar-anamnese text-dark" data-anamneseId=' + full.anamneseId + ' data-candidatoId=' + full.candidatoId + ' data-medicoId=' + full.anamnese.medico?.id + ' data-id=' + data + ' href=""></a>';

                    return '';
                }
            },
            {
                orderable: false,
                data: "id",
                render: function (data, type, full) {
                    return '<a title="Excluir" class="bi bi-trash btn-excluir text-dark" data-id=' + data + ' href=""></a>';
                }
            }
        ]
    });

    oTable.on('click', '.btn-editar', function (e) {
        e.preventDefault();
        let id = $(this).data("id");
        cargoSelecionado = $(this).data('cargoid');
        empresaSelecionada = $(this).data('empresaid');

        let model = {
            Id: id,
            Nome: '',
            RG: '',
            Email: ''
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/candidato/modal/',
            async: true,
            dataType: "html",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (partialView) {
                hideLoading();
                $("#partial-modal").find(".modal-body").html(partialView);
                $("#partial-modal").modal('show');
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    oTable.on('click', '.btn-editar-anamnese', function (e) {
        e.preventDefault();
        let id = $(this).data("id");
                
        let model = {
            Id: id
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/candidato/modalanamnese/',
            async: true,
            dataType: "html",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (partialView) {
                hideLoading();
                $("#partial-modal-anamnese").find(".modal-body").html(partialView);
                $("#partial-modal-anamnese").modal('show');
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    oTable.on('click', '.btn-excluir', function (e) {
        e.preventDefault();
        let id = $(this).data("id");
        $('#id-exclusao').val(id);
        $("#modal-excluir").modal('show');
    });

    oTable.on('click', '.btn-baixar-aso', function (e){
        e.preventDefault();
        let candidatoId = $(this).data("candidatoid");
        let anamneseId = $(this).data("anamneseid");
        let url = '/aso?candidato=' + candidatoId + '&anamnese=' + anamneseId;
        //window.open('/aso?candidato=' + candidatoId + '&anamnese=' + anamneseId, '_blank'); 
        window.location = url;
    });

    $('#btn-criar').click(function (e) {
        e.preventDefault();

        let model = {
            Id: '',
            Nome: '',
            RG: '',
            Email: ''
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/candidato/modal/',
            async: true,
            dataType: "html",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (partialView) {
                hideLoading();
                $("#partial-modal").find(".modal-body").html(partialView);
                $("#partial-modal").modal('show');
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    $("#partial-modal").on('shown.bs.modal', function () {
        $.get("/cargo/getasync/", function (data) {
            $("#cargo").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#cargo").append('<option value=' + obj.id + ' ' + (obj.id == cargoSelecionado ? 'selected' : '') + '>' + obj.descricao + '</option>');
            });
        });
        $.get("/empresa/getasync/", function (data) {
            $("#empresa").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#empresa").append('<option value=' + obj.id + ' ' + (obj.id == empresaSelecionada ? 'selected' : '') + '>' + obj.cnpj + ' - ' + obj.razaoSocial + '</option>');
            });
        });
    });

    $("#partial-modal-anamnese").on('shown.bs.modal', function () {
        $.get("/medico/getasync/", function (data) {
            $("#MedicoId").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#MedicoId").append('<option value=' + obj.id + ' ' + (obj.id == medicoSelecionado ? 'selected' : '') + '>' + obj.crm + ' - ' + obj.nome + '</option>');
            });
        });
    });

    $('#btn-salvar').click(function (e) {
        e.preventDefault();
        var formValid = $('#form-cadastro').valid();
        if (!formValid) {
            return false;
        }

        let id = $('#id').val();
        let nome = $('#nome').val();
        let rg = $('#rg').val();
        let email = $('#email').val();
        let dataNascimento = $("#data-nascimento").val();
        let uf = $("#uf").val();
        let orgaoEmissor = $("#orgao-emissor").val();
        let cargoId = $("#cargo").val();
        let empresaId = $("#empresa").val();

        let type = (id == null || id == '' || id == undefined) ? 'POST' : 'PUT';
        let action = (id == null || id == '' || id == undefined) ? 'postasync' : 'putasync';

        let model = {
            Id: (id == null || id == '' || id == undefined) ? '00000000-0000-0000-0000-000000000000' : id,
            Nome: nome,
            RG: rg,
            Email: email,
            DataNascimento: dataNascimento,
            UF: uf,
            OrgaoEmissor: orgaoEmissor,
            CargoId: cargoId,
            EmpresaId: empresaId
        };

        $.ajax({
            type: type,
            url: '/candidato/' + action,
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (taskResult) {
                hideLoading();
                if (taskResult.isSuccess) {
                    $('#id').val('');
                    $('#nome').val('');
                    $('#rg').val('');
                    $('#email').val('');
                    $('#uf').val('');
                    $('#orgao-emissor').val('');
                    window.location.reload();
                    return;
                }
                console.log(taskResult.errors)
                alertify.error(taskResult.errors.join());
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    $('#btn-salvar-anamnese').click(function (e) {
        e.preventDefault();
        var formValid = $('#form-cadastro').valid();
        if (!formValid) {
            return false;
        }

        if (($("#Apto").val() === 'false')) {
            if ($("#MotivoInapto").val() == '' || $("#MotivoInapto").val() == null || $("#MotivoInapto").val() == undefined) {
                alertify.alert('Informe o motivo pelo qual o candidato foi considerado inapto!');
                return false;
            }
        }
        
        let model = {
            Id: $('#Id').val(),
            CandidatoId: $('#CandidatoId').val(),
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
            QuantosCigarrosDia: parseInt($('#QuantosCigarrosDia').val()),
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
            PortadorDeficienciaMultipla: $('#PortadorDeficienciaMultipla').is(':checked'),
            MedicoId: $("#MedicoId").val(),
            Local: $("#Local").val(),
            Data: $("#Data").val(),
            Apto: ($("#Apto").val() === 'true'),
            MotivoInapto: $("#MotivoInapto").val()
        };

        $.ajax({
            type: 'PUT',
            url: '/anamnese/putasync',
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (taskResult) {
                hideLoading();
                if (taskResult.isSuccess) {
                    $('#id').val('');
                    window.location.reload();
                    return;
                }
                alertify.error(taskResult.errors.join());
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    $('#btn-confirmar').click(function (e) {
        e.preventDefault();

        let candidatoId = $('#id-exclusao').val();

        $.ajax({
            type: 'DELETE',
            url: '/candidato/deleteasync/' + candidatoId,
            async: true,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (taskResult) {
                if (taskResult.isSuccess) {
                    $('#id-exclusao').val('');
                    window.location.reload();
                    return;
                }
                hideLoading();
                alertify.error(taskResult.errors.join());
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    $('#btn-filtro').click(function (e) {
        e.preventDefault();
        oTable.ajax.reload();
    });
});