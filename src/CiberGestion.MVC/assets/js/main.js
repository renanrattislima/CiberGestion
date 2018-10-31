﻿function alerta(titulo, mensagem, reload, href) {
    $('#myModalLabel').text(titulo);
    $('#myModalTexto').html(mensagem);
    $('#myModal').modal('show');

    if (reload == true) {
        $('#myModal .fechar').on('click', function (event) {
            event.preventDefault();
            window.location.reload();
        });
		
    };

    if (href != undefined) {
        $('#myModal .fechar').on('click', function (event) {
            event.preventDefault();
            window.location.href = href
        });
    }
}

function validarData(valor) {
    var date = valor;
    var ardt = new Array;
    var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
    ardt = date.split("/");
    erro = false;
    if (date == "")
        erro == false;
    else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
        erro = true;
    else if (ardt[1] == 2) {
        if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
            erro = true;
        if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
            erro = true;
    } else if (ardt[2] < 1900)
        erro = true;
    else if (date.search(ExpReg) == -1)
        erro = true;

    if (erro)
        return false;
    else
        return true;
}

function validaDataNascimento(valor) {
    var date = valor;
    var ardt = new Array;
    ardt = date.split("/");
    erro = false;
    if (!validarData(valor))
            erro = true;
    else if (ardt[2] > 2014)
        erro = true;

    if (erro)
        return false;
    else
        return true;
}

$(document).ready(function () {
    // #################################################################
    // #################################################################
    // #################################################################
    // ############										    ############
    // ############                 Geral                   ############
    // ############                                         ############
    // #################################################################
    // #################################################################
    // #################################################################

    $("a.em-breve").click(function () {
        alerta("Aviso", "Em breve.");
        return false;
    });
});