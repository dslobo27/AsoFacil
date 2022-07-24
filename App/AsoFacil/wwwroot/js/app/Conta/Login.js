$(document).ready(function () {
    let preloader = $('#preloader');

    $('#btnLogin').click(function (e) {
        e.preventDefault();        
        var formValid = $('#login-form').valid();
        if (!formValid) {
            return false;
        }

        preloader.show();

        let usuario = $('#usuario').val();
        let senha = $('#senha').val();

        let model = {
            Login: usuario,
            Senha: senha
        };

        $.ajax({
            type: 'POST',
            url: '/Conta/Login',
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
                    window.location.href = '/Candidato/Cadastro';
                    return;
                }
                alert(taskResult.errors);
            },
            error: function (e) {
                console.error(e);
            }
        });
    });
});