using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Extencao
{
    public static class DecimalExtensao
    {
        public static decimal Truncate(this decimal valor, int precisao)
        {
            return Math.Truncate(100 * valor) / 100;
        }
    }
}
