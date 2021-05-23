using Aplicacao.Calculadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculadora.Models
{
    public class RetornoViewModel
    {
        public RetornoCalcularJurosView Resultado { get; set; }
        public bool Sucesso { get; set; }
        public string Msg { get; set; }

        internal static RetornoViewModel RetornoErro(string message)
        {
            return new RetornoViewModel
            {
                Msg = message,
                Sucesso = false
            };
        }

        internal static RetornoViewModel RetornoSucesso(RetornoCalcularJurosView resultado)
        {
            return new RetornoViewModel
            {
                Resultado = resultado,
                Sucesso = true
            };
        }
    }
}
