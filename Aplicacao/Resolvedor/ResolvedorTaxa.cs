using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicacao.Resolvedor
{
    public class ResolvedorTaxa : IResolvedorTaxa
    {
        private readonly IConfiguration _configuration;

        public ResolvedorTaxa(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<decimal> ObterTaxaAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("MinhasConfis")["UrlApiJuros"]);

            var respostaApi = await client.GetAsync("Juros/ObterTaxaJuros");

            respostaApi.EnsureSuccessStatusCode();

            var taxa = await respostaApi.Content.ReadAsStreamAsync();

            var tt = await JsonSerializer.DeserializeAsync<decimal>(taxa);
            return tt;
        }


        public class RetornoViewModel 
        {
            public decimal Percentual { get; private set; }
            public bool Sucesso { get; private set; }
            public string Msg { get; private set; }
        }
    }
}
