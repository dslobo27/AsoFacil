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

        let model = {
            CNPJ: cnpj,
            RazaoSocial: razaoSocial,
            Email: email
        };

        $.ajax({
            type: 'POST',
            url: '/Empresa/Post',
            data: JSON.stringify(model),
            async: true,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                showLoading();
            },
            success: function (taskResult) {
                hideLoading();
                console.log(taskResult);
                if (taskResult.isSuccess) {
                    alertify.success('Empresa cadastrada com sucesso!');
                    $('#cnpj').val('');
                    $('#razao-social').val('');
                    $('#email').val('');
                    return;
                }
                alertify.error(taskResult.errors);
            },
            error: function (e) {
                console.error(e);
            }
        });
    });
});