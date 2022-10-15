$(document).ready(function () {
    var candidatoSelecionado = '';
    var statusSelecionado = '';

    var oTable = $("#table-agendamentos").DataTable({
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
            url: '/agendamento/getasync',
            data: function (d) {
                d.nome = $('#filtro-nome').val();
                d.rg = $('#filtro-rg').val();
                d.dtInicio = $('#filtro-dtInicio').val();
                d.dtFim = $('#filtro-dtFim').val();
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
                    return '<a title="Editar" class="bi bi-pencil-square btn-editar text-dark" data-statusId=' + full.statusAgendamento.id + ' data-candidatoId=' + full.candidatoId + ' data-id=' + data + ' href=""></a>';
                }
            },
            { data: "statusAgendamento.descricao", "autowidth": true },
            { data: "candidato.rg", "autowidth": true },
            { data: "candidato.nome", "autowidth": true },            
            { data: "empresa.razaoSocial", "autowidth": true },
            {
                data: "dataHora",
                "autowidth": true,
                render: function (data, type, full) {
                    [yyyy, mm, dd, hh, mi] = full.dataHora.split(/[/:\-T]/);
                    return `${dd}/${mm}/${yyyy} ${hh}:${mi}`;
                }
            },
            {
                data: "id",
                "autowidth": true,
                render: function (data, type, full) {
                    return '<a title="link para preenchimento da anamnese do candidato" class="bi bi-link-45deg btn-link text-dark" data-url="/CoreBusiness/Anamnese?candidato=' + full.candidatoId + '&agendamento=' + data + '" href=""></a>';
                }
            }
        ]
    });

    oTable.on('click', '.btn-link', function (e) {
        e.preventDefault();
        let url = $(this).data("url");
        window.open(url, "_blank");
    });

    oTable.on('click', '.btn-editar', function (e) {
        e.preventDefault();
        let id = $(this).data("id");
        candidatoSelecionado = $(this).data('candidatoid');
        statusSelecionado = $(this).data('statusid');
        
        let model = {
            Id: id            
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/agendamento/modal/',
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

    oTable.on('click', '.btn-excluir', function (e) {
        e.preventDefault();
        let id = $(this).data("id");
        $('#id-exclusao').val(id);
        $("#modal-excluir").modal('show');
    });

    $('#btn-criar').click(function (e) {
        e.preventDefault();

        let model = {
            Id: ''
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/agendamento/modal/',
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
        $.get("/candidato/getasync/", function (data) {
            $("#candidato").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#candidato").append('<option value=' + obj.id + ' ' + (obj.id == candidatoSelecionado ? 'selected' : '') + '>' + obj.nome + ' - [RG - ' + obj.rg + ']</option>');                
            });
        });
        $.get("/statusagendamento/getasync/", function (data) {
            $("#status").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#status").append('<option value=' + obj.id + ' ' + (obj.id == statusSelecionado ? 'selected' : '') + '>' + obj.descricao + '</option>');
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
        let candidato = $('#candidato').val();
        let status = $('#status').val();
        let data = $("#data").val();
        let hora = $("#hora").val();

        let type = (id == null || id == '' || id == undefined) ? 'POST' : 'PUT';
        let action = (id == null || id == '' || id == undefined) ? 'postasync' : 'putasync';

        let model = {
            Id: (id == null || id == '' || id == undefined) ? '00000000-0000-0000-0000-000000000000' : id,
            CandidatoId: candidato,
            StatusAgendamentoId: status,
            DataHora: new Date(data + ' ' + hora)
        };

        console.log(model);

        $.ajax({
            type: type,
            url: '/agendamento/' + action,
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

        let agendamentoId = $('#id-exclusao').val();

        $.ajax({
            type: 'DELETE',
            url: '/agendamento/deleteasync/' + agendamentoId,
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