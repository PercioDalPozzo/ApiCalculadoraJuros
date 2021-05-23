using System;
using System.Threading.Tasks;

namespace Aplicacao.Calculadora
{
    public interface IAplicCalculadora
    {
        Task<RetornoCalcularJurosView> CalcularJuros(CalcJurosView view);
    }
}
