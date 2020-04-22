using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento)
        {
            return tipoPessoa == 1 ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataNomeTipoPessoa(this RazorPage page, int tipoPessoa)
        {
            return tipoPessoa == 1 ? "Pessoa Física" : "Pessoa Jurídica";
        }

        public static string retornaSaudacao(this RazorPage page)
        {
            var hora = DateTime.Now.Hour;
            string saudacao = string.Empty;

            if(hora < 5)
            {
                saudacao = "Boa noite";

            }else if (hora < 12){

                saudacao = "Bom dia";

            }else if(hora < 18)
            {
                saudacao = "Boa tarde";
            }
            else
            {
                saudacao = "Boa noite";
            }

            return saudacao;
        }

    }
}
