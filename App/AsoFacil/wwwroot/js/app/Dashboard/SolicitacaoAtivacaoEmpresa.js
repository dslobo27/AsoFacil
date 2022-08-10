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
                    let url = "/dashboard/ativarempresa/" + data;
                    return '<a title="Ativar empresa" class="bi bi-check-circle" href=' + url +'></a>';
                }
            }
        ]
    });
});