using Aplicacao.Resolvedor;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Calculadora
{
    public class AplicCalculadora : IAplicCalculadora
    {
        private readonly IResolvedorTaxa _resolvedorTaxa;
        public AplicCalculadora(IResolvedorTaxa resolvedorTaxa)
        {
            _resolvedorTaxa = resolvedorTaxa;
        }

        public async Task<RetornoCalcularJurosView> CalcularJuros(CalcJurosView view)
        {
            var taxa = await _resolvedorTaxa.ObterTaxaAsync();
            var valorJurosPorMes = decimal.Round((view.Valor * (taxa / 100)),2);
            var jurosTotalCalculado = decimal.Round(valorJurosPorMes * view.QtMeses, 2);

            var retorno = new RetornoCalcularJurosView();
            retorno.Taxa = taxa;
            retorno.ValorJurosPorMes = valorJurosPorMes;
            retorno.ValorJuros = jurosTotalCalculado;
            retorno.ValorTotal = view.Valor + jurosTotalCalculado;
            return retorno;
        }
    }
}
