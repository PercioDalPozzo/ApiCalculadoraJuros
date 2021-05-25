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
        public async Task Teste_CalculoSolicitadoNoTeste()
        {
            // arrange
            var mockResolvedorTaxa = new Mock<IResolvedorTaxa>();
            mockResolvedorTaxa.Setup(p => p.ObterTaxaAsync()).ReturnsAsync(0.01m);

            var _aplicCalculadora = new AplicCalculadora(mockResolvedorTaxa.Object);
            var view = new CalcJurosView();
            view.QtMeses = 5;
            view.Valor = 100m;


            // action
            var retorno = await _aplicCalculadora.CalcularJuros(view);

            // assert
            Assert.AreEqual(1.02m, retorno.MediaJurosPorMes);
            Assert.AreEqual(5.1m, retorno.ValorJuros);
            Assert.AreEqual(105.1m, retorno.ValorTotal);
        }

        [TestMethod]
        public async Task Teste_CalculoTruncandoOutrosValores()
        {
            // arrange
            var mockResolvedorTaxa = new Mock<IResolvedorTaxa>();
            mockResolvedorTaxa.Setup(p => p.ObterTaxaAsync()).ReturnsAsync(0.03m);

            var _aplicCalculadora = new AplicCalculadora(mockResolvedorTaxa.Object);
            var view = new CalcJurosView();
            view.QtMeses = 12;
            view.Valor = 7.77m;

            // action
            var retorno = await _aplicCalculadora.CalcularJuros(view);

            // assert
            Assert.AreEqual(0.27m, retorno.MediaJurosPorMes);
            Assert.AreEqual(3.3m, retorno.ValorJuros);
            Assert.AreEqual(11.07m, retorno.ValorTotal);
        }
    }
}
