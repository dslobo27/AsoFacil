$(document).ready(function () {
    let preloader = $('#preloader');
    $('#btn-cadastro').click(function (e) {
        e.preventDefault();
        var formValid = $('#form-cadastro').valid();
        if (!formValid) {
            return false;
        }

        preloader.show();

        let cnpj = $('#cnpj').val();
        let razaoSocial = $('#razao-social').val();
        let email = $('#email').val();
        let flagClinica = $("#flagClinica").is(':checked');

        let model = {
            CNPJ: cnpj,
            RazaoSocial: razaoSocial,
            Email: email,
            FlagClinica: flagClinica
        };

        $.ajax({
            type: 'POST',
            url: '/empresa/postasync',
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
                    alertify.success('Empresa cadastrada com sucesso!');
                    $('#cnpj').val('');
                    $('#razao-social').val('');
                    $('#email').val('');
                    return;
                }
                alertify.error(taskResult.errors.join());
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    $('#btn-voltar').click(function (e) {
        e.preventDefault();
        window.location.href = '/Conta/Index';
    });
});