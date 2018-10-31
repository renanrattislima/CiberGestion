$(function () {

    var descricao = "";

    $('#btBuscar').on('click', function (e) {

        e.preventDefault();

        var arquivo = $('#rede').val();


        $('#loading').fadeIn();

        $('#table > tbody').html('');
        $('#table').hide();


        var selectFabricante = "";
        var selectCategoria = "";


        $.post('/Ferramenta/ListarFabricante', {}, function (resultFabricante) {

            selectFabricante = "<select  name='ddlFabricante' class='form-control ddlFabricante'><option value=''>Selecione...</option>";

            $(resultFabricante).each(function (index, data) {
                selectFabricante += "<option value='" + data.Valor + "'>" + data.Texto + "</option>";
            });

            selectFabricante += "</select>";

        }).done(function () {

            selectCategoria = "<select name='ddlCategoria' class='form-control ddlCategoria'><option value=''>Selecione...</option>";

            $.post('/Ferramenta/ListarCategoria', {}, function (resultCategoria) {

                $(resultCategoria).each(function (index, data) {
                    selectCategoria += "<option value='" + data.Valor + "'>" + data.Texto + "</option>";
                });

                selectCategoria += "</select>";

            }).done(function () {


                $.post('/Ferramenta/ListarProduto', { idArquio: arquivo }, function (dados) {

                    var linhas = "";
                    var selectProduto = "<select name='ddlProduto' class='form-control ddlProduto'><option value=''>Selecione...</option></select>";

                    $(dados).each(function (index, data) {

                        linhas += "<tr>";
                        linhas += "<td>" + data.dsRede + "</td>";
                        linhas += "<td>" + data.dsCategoria + "</td>";
                        linhas += "<td>" + data.dsDescricaoProduto + "</td>";

                        linhas += "<td class='fabricante'>" + selectFabricante + "</td>";
                        linhas += "<td class='categoria'>" + selectCategoria + "</td>";
                        linhas += "<td class='produto'>" + selectProduto + "</td>";

                        linhas += "<input type='hidden' name='descricao' value='" + data.dsDescricaoProduto + "'/><td class='inexistente'><input type='checkbox' name='chkInexistente' class='chkInexistente'/></td>";

                        linhas += "<td><input type='hidden' name='arquivoId' value='" + data.idArquivo + "'/><input type='button' value='Salvar' id='btSalvar' class='btn btn-primary gray' /></td>";

                        linhas += "</tr>";


                    });

                    if (linhas.length > 0) {

                        $('#table > tbody').append(linhas);
                        $('#table').show();
                    }
                    else {

                        alerta('Aviso', 'Nenhum arquivo pendente.');
                    }

                    $('#loading').fadeOut();

                });
            });
        });
    });

    $('body').on('change', '.ddlCategoria', function (e) {

        e.preventDefault();

        var s = $(this).parent().parent().index();

        var categoria = $('.ddlCategoria:eq(' + s + ')').val();
        var fabricante = $('.ddlCategoria:eq(' + s + ')').parent().parent().find('.ddlFabricante').val();

        if (categoria == "") {

            $('.ddlCategoria:eq(' + s + ')').parent().parent().find('.ddlProduto').empty();

            $('.ddlCategoria:eq(' + s + ')').parent().parent().find('.ddlProduto').html("<option value=''>Selecione...</option>");;

        } else {

            $('#loading').fadeIn();

            $.post('/Ferramenta/ListarProdutoSKU', { fabricante: fabricante, categoria: categoria }, function (lista) {

                if (lista.length == 0) {


                    $('.ddlCategoria:eq(' + s + ')').parent().parent().find('.ddlProduto').empty();
                    $('.ddlCategoria:eq(' + s + ')').parent().parent().find('.ddlProduto').html("<option value=''>Selecione...</option>");
                    $('#loading').fadeOut();

                } else {

                    var listaSku = "<option value=''>Selecione...</option>";

                    $(lista).each(function (index, data) {

                        listaSku += "<option name='produtoSKU' value='" + data.dsSKU + ";" + data.idProduto + "'" + ">" + data.Descricao + "</option>";

                    });

                    $('.ddlCategoria:eq(' + s + ')').parent().parent().find('.ddlProduto').html(listaSku);

                    //$('.ddlProduto').html(listaSku);
                    $('#loading').fadeOut();
                }
            });
        }
    });

    $('body').on('click', '#btSalvar', function (e) {

        var produto = $(this).parent().parent().find('.ddlProduto').val();
        var isInexistente = $(this).parent().parent().find('.chkInexistente').is(':checked');
        var arquivo = $(this).prev('input').val();
        var descricao = $(this).parent().parent().find('.inexistente').prev('input').val();;
        var isValida = true;

        if (!isInexistente) {

            if (produto == "") {
                isValida = false;
            }
        }


        if (isValida) {


            $('#loading').fadeIn();

            $.post('/Ferramenta/CadastrarProdutos', { produto: produto, arquivo: arquivo, isInexistente: isInexistente, descricao: descricao }, function (retorno) {

                $('#loading').fadeOut();

                $('#btBuscar').click();

            });

        } else {

            alerta('Aviso!', 'Selecione um produto');
        }
    });

    $('body').on('change', '.chkInexistente', function (e) {

        e.preventDefault();

        if ($(this).is(':checked')) {

            $(this).parent().parent().find('.ddlProduto').attr('disabled', 'disabled');
            $(this).parent().parent().find('.ddlCategoria').attr('disabled', 'disabled');
            $(this).parent().parent().find('.ddlFabricante').attr('disabled', 'disabled');

        } else {

            $(this).parent().parent().find('.ddlProduto').removeAttr('disabled', 'disabled');
            $(this).parent().parent().find('.ddlCategoria').removeAttr('disabled', 'disabled');
            $(this).parent().parent().find('.ddlFabricante').removeAttr('disabled', 'disabled');

        }

    });

});
