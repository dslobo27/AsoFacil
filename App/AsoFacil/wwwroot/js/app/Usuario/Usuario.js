﻿$(document).ready(function () {
    var empresaSelecionada = '';
    var tipoUsuarioSelecionado = '';

    var oTable = $("#table-usuarios").DataTable({
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
            url: '/usuario/getasync',
            data: function (d) {
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
                    return '<a title="Editar" class="bi bi-pencil-square btn-editar text-dark" data-empresaId=' + full.empresa.id + ' data-tipoUsuarioId=' + full.tipoUsuario.id + ' data-id=' + data + ' href=""></a>';
                }
            },
            { data: "login", "autowidth": true },
            { data: "tipoUsuario.descricao", "autowidth": true },
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
        tipoUsuarioSelecionado = $(this).data('tipousuarioid');
        empresaSelecionada = $(this).data('empresaid');

        let model = {
            Id: id,
            Login: ''     
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/usuario/modal/',
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
            Login: ''
        };

        $.ajax({
            type: 'POST',
            data: JSON.stringify(model),
            url: '/usuario/modal/',
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
        $.get("/tipousuario/getasync/", function (data) {
            $("#tipo-usuario").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#tipo-usuario").append('<option value=' + obj.id + ' ' + (obj.id == tipoUsuarioSelecionado ? 'selected' : '') + '>' + obj.codigo + ' - ' + obj.descricao + '</option > ');
            });
        });
        $.get("/empresa/getasync/", function (data) {
            $("#empresa").append('<option value="">Selecione</option>');
            $.each(data, function (key, obj) {
                $("#empresa").append('<option value=' + obj.id + ' ' + (obj.id == empresaSelecionada ? 'selected' : '') + '>' + obj.cnpj + ' - ' + obj.razaoSocial + '</option>');
            });
        });
    })

    $('#btn-salvar').click(function (e) {
        e.preventDefault();
        var formValid = $('#form-cadastro').valid();
        if (!formValid) {
            return false;
        }

        let id = $('#id').val();
        let login = $('#login').val();
        let senha = $('#senha').val();
        let tipoUsuarioId = $('#tipo-usuario').val();
        let empresaId = $('#empresa').val();

        let type = (id == null || id == '' || id == undefined) ? 'POST' : 'PUT';
        let action = (id == null || id == '' || id == undefined) ? 'postasync' : 'putasync';

        let model = {
            Id: (id == null || id == '' || id == undefined) ? '00000000-0000-0000-0000-000000000000' : id,
            Login: login,
            Senha: senha,
            TipoUsuarioId: tipoUsuarioId,
            EmpresaId: empresaId
        };

        $.ajax({
            type: type,
            url: '/usuario/' + action,
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
                    $('#login').val('');
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

        let usuarioId = $('#id-exclusao').val();

        $.ajax({
            type: 'DELETE',
            url: '/usuario/deleteasync/' + usuarioId,
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