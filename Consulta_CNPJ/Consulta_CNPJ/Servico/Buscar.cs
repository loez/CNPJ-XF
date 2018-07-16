using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Consulta_CNPJ.Servico;


namespace Consulta_CNPJ.Servico
{
    public class Buscar
    {
        private static string EnderecoURL = "https://receitaws.com.br/v1/cnpj/{0}";

        public static CNPJ Buscarcnpj(string cnpj)
        {
            string novoenderecourl = string.Format(EnderecoURL, cnpj);

            WebClient wc = new WebClient();
             string conteudo = wc.DownloadString(novoenderecourl);
            

            CNPJ cnpjconvert = JsonConvert.DeserializeObject<CNPJ>(conteudo);
            

            return cnpjconvert;
            
        }



    }
}
