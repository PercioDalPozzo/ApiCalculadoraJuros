using Aplicacao.Resolvedor;
using System;
using System.Threading.Tasks;
using Aplicacao.Extencao;

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
          
            var valorCalculado = view.Valor * (decimal)(Math.Pow((double)taxa+1, view.QtMeses));                        
            
            var valorCalculadoTruncado = valorCalculado.Truncate(2);

            var retorno = new RetornoCalcularJurosView();
            retorno.Taxa = taxa;
            retorno.ValorJuros = valorCalculadoTruncado - view.Valor;
            retorno.MediaJurosPorMes =(retorno.ValorJuros / view.QtMeses).Truncate(2);
            retorno.ValorTotal = valorCalculadoTruncado;
            return retorno;
        }
    }
}
