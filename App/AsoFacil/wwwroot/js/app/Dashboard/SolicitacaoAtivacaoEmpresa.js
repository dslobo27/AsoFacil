$(document).ready(function () {
    var oTable = $("#table-solicitacao-ativacao-empresa").DataTable({
        pagingType: 'full_numbers',
        pageLength: 10,
        processing: true,
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
            url: '/dashboard/solicitacoesativacoesempresas',
            data: '',
            dataSrc: '',
            type: "GET",
            async: true,
            dataType: "json"
        },
        columns: [            
            { data: "empresaModel.cnpj", "autowidth": true },
            { data: "empresaModel.razaoSocial",  "autowidth": true },
            { data: "empresaModel.email",  "autowidth": true },
            { data: "statusSolicitacaoAtivacaoEmpresaModel.descricao", "autowidth": true },
            {
                data: "id",
                render: function (data, type, full) {
                    return '<a title="Ativar empresa" class="bi bi-check-circle btn-ativar-empresa" data-id='+ data +' href=""></a>';
                }
            }
        ]
    });

    oTable.on('click', '.btn-ativar-empresa', function (e) {
        e.preventDefault();
        let solicitacaoAtivacaoEmpresaId = $(this).data("id");

        $.ajax({
            type: 'PUT',
            url: '/dashboard/ativarempresa/' + solicitacaoAtivacaoEmpresaId,
            async: true,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (taskResult) {
                if (taskResult.isSuccess) {
                    alertify.success('Empresa cadastrada com sucesso!');
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
});