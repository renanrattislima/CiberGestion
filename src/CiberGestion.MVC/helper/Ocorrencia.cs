using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CiberGestion.Dominio.Util;

namespace CiberGestion.MVC.helper
{
    public static class Ocorrencia
    {
        public static MvcHtmlString Tela(this HtmlHelper html)
        {

            var box = new StringBuilder();
            var usuario = Geral.recuperaCookie();

            if (usuario.idTipo == 1 || usuario.idTipo == 2)
            {
                box.Append(html.Partial("_OcorrenciaDetalhesWhirpoolFullbar"));
            }
            else
            {
                box.Append(html.Partial("_OcorrenciaDetalhesSac"));
            }


            return MvcHtmlString.Create(box.ToString());
        }

        public static MvcHtmlString Menu(this HtmlHelper html)
        {
            var menu = new StringBuilder();
            var usuario = Geral.recuperaCookie();

            //if (usuario.idTipo != 3)
            //{
            menu.Append("<li>");

            menu.Append("<a href='#'><i class='fa fa-edit fa-fw'></i> FERRAMENTAS</a>");
            menu.Append("<ul class='nav nav-second-level'>");
            menu.Append("<li>");
            menu.Append("<a href='/Ferramenta/ClassificacaoSKU')>CLASSIFICAÇÃO SKU</a>");
            menu.Append("</li>");
            if (usuario.idTipo == 1 || usuario.idTipo == 4)
            {
                menu.Append("<li>");
                menu.Append("<a href='/Ferramenta/Estorno')>ESTORNO PEDIDOS</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Pontos/Index')>TABELA DE PONTOS CONSULTA</a>");
                menu.Append("</li>");

               

            }
            if (usuario.idTipo == 4) {
                menu.Append("<li>");
                menu.Append("<a href='/Pontos/InclusaoManualProdutos')>IMPORTAÇÃO DE PRODUTOS</a>");
                menu.Append("</li>");
            }
            menu.Append("</ul>");
            menu.Append("</li>");
            menu.Append("<li>");

            menu.Append("<a href='#'><i class='fa fa-picture-o'></i> BANNER</a>");
            menu.Append("<ul class='nav nav-second-level'>");
            menu.Append("<li>");
            menu.Append("<a href='/Banner/Index')>Banner Principal / Listar</a>");
            menu.Append("</li>");

            menu.Append("<li>");
            menu.Append("<a href='/Banner/Cadastrar')>Banner Principal / Cadastrar</a>");
            menu.Append("</li>");

            menu.Append("</ul>");
            menu.Append("</li>");

            //}

            menu.Append("<li>");

            menu.Append("<a href='#'><i class='fa fa-cog' ></i>  SAC</a>");
            menu.Append("<ul class='nav nav-second-level'>");

            menu.Append("<li>");
            menu.Append("<a href='/Home')>VISÃO GERAL</a>");
            menu.Append("</li>");

            menu.Append("<li>");
            menu.Append(String.Format("<a href='/Ocorrencia')>{0}</a>", (usuario.idTipo == 3 || usuario.idTipo == 4 || usuario.idTipo == 2) ? "PESQUISAR OCORRÊNCIA" : "MINHAS PENDÊNCIAS"));
            menu.Append("</li>");

            if (usuario.idTipo == 3 || usuario.idTipo == 4)
            {
                menu.Append("<li>");
                menu.Append("<a href='/Ocorrencia/Cadastrar')>NOVA OCORRÊNCIA</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Participante/ReenviarSenha')>REENVIO DE SENHA</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Participante/ReenviarSmsAtivacao')>REENVIO DE SMS ATIVAÇÃO</a>");
                menu.Append("</li>");




                menu.Append("<li>");
                menu.Append("<a href='/Participante/SMS')>LOG DE SMS ATIVAÇÃO</a>");
                menu.Append("</li>");

            }

            menu.Append("<li>");
            menu.Append("<a href='/Ocorrencia/AcessoEspelho')>ACESSO ESPELHO</a>");
            menu.Append("</li>");

            menu.Append("</ul>");
            menu.Append("</li>");


            menu.Append("<li>");

            menu.Append("<a href='#'><i class='fa fa-user fa-fw'></i> USUÁRIOS ADMIN</a>");
            menu.Append("<ul class='nav nav-second-level'>");
            menu.Append("<li>");
            menu.Append("<a href='/Usuario/AtualizarSenha')>ATUALIZAÇÃO DE SENHA</a>");
            menu.Append("</li>");

            if (usuario.idTipo == 4 )
            {
                menu.Append("<li>");
                menu.Append("<a href='/Usuario/UsuariosAdmin')>USUÁRIOS ADMIN</a>");
                menu.Append("</li>");
            }

            menu.Append("</ul>");
            menu.Append("</li>");

            if (usuario.idTipo == 4 || usuario.idTipo == 2)
            {
                menu.Append("<li>");

                menu.Append("<a href='#'><i class='fa fa-fw fa-dashboard'></i> DASHBOARD</a>");
                menu.Append("<ul class='nav nav-second-level'>");

                menu.Append("<li>");
                menu.Append("<a href='/Home/Dashboard')>HOME</a>");
                menu.Append("</li>");

                menu.Append("<li>");

                menu.Append("<a href='#'><i class='fa fa-file-o'></i> PLANEJAMENTOS</a>");
                menu.Append("<ul class='nav nav-third-level'>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Planejamento') style=''>   PLANEJAMENTO</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Investimento') style=''>   INVESTIMENTO</a>");
                menu.Append("</li>");

                menu.Append("</ul>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Cadastros')>CADASTROS</a>");
                menu.Append("</li>");

                menu.Append("<li>");

                menu.Append("<a href='#'><i class='fa fa-file-o'></i> KPI'S</a>");
                menu.Append("<ul class='nav nav-third-level'>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Kpis')>   SELOS</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Treinamento')>   TREINAMENTO</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Acessos')>   ACESSOS</a>");
                menu.Append("</li>");

                menu.Append("</ul>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Pontos')>PONTOS</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Vendas')>VENDAS</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Comunicacao')>COMUNICAÇÃO</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Dashboard/Sac')>SAC</a>");
                menu.Append("</li>");

                menu.Append("</ul>");
                menu.Append("</li>");
            }

            if (usuario.idTipo == 4)
            {
                menu.Append("<li>");

                menu.Append("<a href='#'><i class='fa fa-wrench fa-fw'></i> MANUTENÇÃO</a>");

                menu.Append("<ul class='nav nav-second-level'>");
                menu.Append("<li>");
                menu.Append("<a href='/Lojas')>CADASTRO DE LOJAS</a>");
                menu.Append("</li>");

                menu.Append("<li>");
                menu.Append("<a href='/Usuarios')>CADASTRO DE USUÁRIOS</a>");
                menu.Append("</li>");

                menu.Append("</ul>");
                menu.Append("</li>");
            }

            return MvcHtmlString.Create(menu.ToString());
        }

    }
}