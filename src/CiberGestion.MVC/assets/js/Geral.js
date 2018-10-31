
$(function() {

    var mensagem = $('#mensagemLogin').val();

    if (mensagem != '') {

        alerta(mensagem);
    }

    $('input[name="btnEntrar"]').on("click", function () {

        $('#loading').fadeIn();

    });

});