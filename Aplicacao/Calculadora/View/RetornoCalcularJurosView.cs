using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Calculadora
{
    public class RetornoCalcularJurosView
    {
        public decimal Taxa { get; set; }
        public decimal ValorJurosPorMes { get; set; }        
        public decimal ValorJuros { get; set; }
        public decimal ValorTotal{ get; set; }
    }
}
