using ApiCalculadora.Models;
using Aplicacao.Calculadora;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
//using Xunit;

namespace TesteUnitario.Integracao
{    
    [TestClass]
    public class TesteIntegracao
    {
        
        [TestMethod]
        public async Task Teste_ApiCalculoOnLine()
        {
            // arrange
            var apiJuros = new ApiCalculadora();

            // action
            var response = await apiJuros.Client.GetAsync("Calculadora/CalcularJuros");
            response.EnsureSuccessStatusCode();

            // assert
            Assert.IsTrue(response.IsSuccessStatusCode, "Api de calculo não subiu");
        }

        [TestMethod]
        public async Task Teste_CalculoRetornaCorreto()
        {
            // arrange
            var url = QueryHelpers.AddQueryString("Calculadora/CalcularJuros", new Dictionary<string, string>
            {
                { "QtMeses", "6" },
                { "Valor", "200.11" },
            });

            var apiJuros = new ApiCalculadora();
            var response = await apiJuros.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content =await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var retornoTipado = await JsonSerializer.DeserializeAsync<RetornoCalcularJurosView>(content, options);

            // assert               
            Assert.AreEqual(10m, retornoTipado.Taxa);
            Assert.AreEqual(120.06m, retornoTipado.ValorJuros);
            Assert.AreEqual(20.01m, retornoTipado.MediaJurosPorMes);
            Assert.AreEqual(320.17, retornoTipado.ValorTotal);
        }



        // [TestMethod]
        //public async Task Teste_CalculoRetornaCorreto()
        // {
        //     // Arrange
        //     var client = new WebApplicationFactory<Startup>();

        //     // Act
        //     var response = await client.GetAsync("Calculadora/CalcularJuros");

        //     // Assert
        //     response.EnsureSuccessStatusCode(); // Status Code 200-299
        //     Assert.AreEqual("text/html; charset=utf-8",
        //         response.Content.Headers.ContentType.ToString());
        // }
    }
}
