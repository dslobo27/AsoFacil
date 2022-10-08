$(document).ready(function () {
    var oTable = $("#table-status-agendamentos").DataTable({
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
            url: '/statusagendamento/getasync',
            data: function (d) {
                d.descricao = $('#filtro-descricao').val();
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
                    return '<a title="Editar" class="bi bi-pencil-square btn-editar text-dark" data-descricao=' + full.descricao + ' data-id=' + data + ' href=""></a>';
                }
            },
            { data: "descricao", "autowidth": true },
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
        let descricao = $(this).data("descricao");

        let model = {
            Id: id,
            Descricao: descricao
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/statusagendamento/modal/',
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
            Id: '',
            Descricao: ''
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/statusagendamento/modal/',
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

    $('#btn-salvar').click(function (e) {
        e.preventDefault();
        var formValid = $('#form-cadastro').valid();
        if (!formValid) {
            return false;
        }

        let id = $('#id').val();
        let descricao = $('#descricao').val();

        let type = (id == null || id == '' || id == undefined) ? 'POST' : 'PUT';
        let action = (id == null || id == '' || id == undefined) ? 'postasync' : 'putasync';
                
        let model = {
            Id: (id == null || id == '' || id == undefined) ? '00000000-0000-0000-0000-000000000000' : id,
            Descricao: descricao
        };

        $.ajax({
            type: type,
            url: '/statusagendamento/' + action,
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
                    $('#id').val('');
                    $('#descricao').val('');
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

        let statusAgendamentoId = $('#id-exclusao').val();

        $.ajax({
            type: 'DELETE',
            url: '/statusagendamento/deleteasync/' + statusAgendamentoId,
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