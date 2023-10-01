using CepCSharp_API.Entities.DTOs;
using CepCSharp_API.Entities.Records;
using System.Runtime.ConstrainedExecution;

namespace CepCSharp_API.Servicies
{
    public class CepService
    {
        private static string _url = "https://viacep.com.br/ws/";
        private static HttpClient client = new HttpClient();    

        public async Task<CepDto?> GetCep(CepRecord request) 
        {
            try
            {
                if (request.Cep.Contains("-"))
                {
                    request.Cep = request.Cep.Replace("-", "");
                }
                HttpResponseMessage response = client.GetAsync($"{_url}{request.Cep}/json").Result;
                CepDto result = new CepDto();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadFromJsonAsync<CepDto>().Result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
