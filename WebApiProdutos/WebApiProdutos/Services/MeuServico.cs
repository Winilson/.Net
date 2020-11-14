using System;

namespace WebApiProdutos.Services
{
    public class MeuServico : IMeuServico
    {
        public string Saudacao(string nome)
        {
            return $"Bem Vindo, {nome} \n\n {DateTime.Now}";
        }
    }
}
