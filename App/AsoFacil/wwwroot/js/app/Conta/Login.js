$(document).ready(function () {
    $('#btnLogin').click(function (e) {
        e.preventDefault();
        let usuario = $('#usuario').val();
        let senha = $('#senha').val();

        let model = {
            Login: usuario,
            Senha: senha
        };

        $.ajax({
            type: 'POST',
            url: 'Conta/Login',
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (ret) {
                if (ret) {
                    console.log('teste');
                }                
            },
            error: function (e) {
                alert(e);
            }
        });
    });
});