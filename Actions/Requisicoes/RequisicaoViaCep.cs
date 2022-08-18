using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Actions.Requisicoes
{
    public static class ViaCep
    {
        public static async Task<string> RequisicaoViaCep(string cep)
        {
            try
            {
                HttpClient client = new HttpClient();
                var resultado = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
