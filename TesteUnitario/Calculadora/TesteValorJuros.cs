using Aplicacao.Calculadora;
using Aplicacao.Resolvedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace TesteUnitario
{
    [TestClass]
    public class TesteValorJuros
    {
        [TestMethod]
        public async Task Teste_ResultadoCalculoJuros()
        {
            // arrange
            var mockResolvedorTaxa = new Mock<IResolvedorTaxa>();
            mockResolvedorTaxa.Setup(p => p.ObterTaxaAsync()).ReturnsAsync(7.77m);

            var _aplicCalculadora = new AplicCalculadora(mockResolvedorTaxa.Object);
            var view = new CalcJurosView();
            view.QtMeses = 6;
            view.Valor = 200.11m;


            // action
            var retorno = await _aplicCalculadora.CalcularJuros(view);

            // assert
            Assert.AreEqual(93.3m, retorno.ValorJuros);
            Assert.AreEqual(293.41m, retorno.ValorTotal);
        }
    }
}
