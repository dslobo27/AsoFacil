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
        let lembrarDeMim = $('#remember-me').is(':checked');

        let model = {
            Login: usuario,
            Senha: senha,
            LembrarDeMim: lembrarDeMim
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
                if (taskResult.isSuccess) {
                    window.location.href = taskResult.urlRedirect;
                    return;
                }
                hideLoading();
                alertify.error(taskResult.errors[0]);                
            },
            error: function (e) {
                console.error(e);
            }
        });
    });
});