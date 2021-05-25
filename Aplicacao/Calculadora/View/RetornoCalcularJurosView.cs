using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Calculadora
{
    public class RetornoCalcularJurosView
    {
        public decimal Taxa { get; set; }
        public decimal MediaJurosPorMes { get; set; } // Meramente informativo
        public decimal ValorJuros { get; set; }
        public decimal ValorTotal{ get; set; }
    }
}
