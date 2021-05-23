using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Resolvedor
{
    public interface IResolvedorTaxa
    {
        Task<decimal> ObterTaxaAsync();
    }
}
