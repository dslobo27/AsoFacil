$(document).ready(function () {
    var oTable = $("#table-empresas").DataTable({
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
            url: '/empresa/getasync',
            data: function (d) {
                d.cnpj = $('#filtro-cnpj').val();
                d.razaoSocial = $('#filtro-razaoSocial').val();
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
                    return '<a title="Editar" class="bi bi-pencil-square btn-editar text-dark" data-cnpj=' + full.cnpj + ' data-id=' + data + ' href=""></a>';
                }
            },
            { data: "cnpj", "autowidth": true },
            { data: "razaoSocial", "autowidth": true },
            {
                data: "flagClinica",
                render: function (data, type, full) {
                    return data ? 'Sim' : 'Não';
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
        
        let model = {
            Id: id
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/empresa/modal/',
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
            CNPJ: '',
            RazaoSocial: '',
            Email: ''
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/empresa/modal/',
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
        let cnpj = $('#cnpj').val();
        let razaoSocial = $('#razao-social').val();
        let email = $('#email').val();
        let ativa = $("#ativa").is(':checked');
        let flagClinica = $("#flagClinica").is(':checked');


        let type = (id == null || id == '' || id == undefined) ? 'POST' : 'PUT';
        let action = (id == null || id == '' || id == undefined) ? 'postasync' : 'putasync';

        let model = {
            Id: (id == null || id == '' || id == undefined) ? '00000000-0000-0000-0000-000000000000' : id,
            CNPJ: cnpj,
            RazaoSocial: razaoSocial,
            Email: email,
            Ativa: ativa,
            FlagClinica: flagClinica
        };

        $.ajax({
            type: type,
            url: '/empresa/' + action,
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
                    $('#cnpj').val('');
                    $('#razaoSocial').val('');
                    $('#email').val('');
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

        let empresaId = $('#id-exclusao').val();

        $.ajax({
            type: 'DELETE',
            url: '/empresa/deleteasync/'+ empresaId,
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