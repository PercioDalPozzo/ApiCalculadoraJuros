using ApiCalculadora.Models;
using Aplicacao.Calculadora;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculadora.Controllers
{
    public class CalculadoraController : Controller
    {
        private readonly IAplicCalculadora _aplicCalculadora;

        public CalculadoraController(IAplicCalculadora aplicCalculadora)
        {
            _aplicCalculadora = aplicCalculadora;
        }

        public async Task<RetornoViewModel> CalcularJuros(CalcJurosView view)
        {
            try
            {
                var retorno = await _aplicCalculadora.CalcularJuros(view);
                return RetornoViewModel.RetornoSucesso(retorno);
            }
            catch (Exception e)
            {
                return RetornoViewModel.RetornoErro(e.Message);
            }
        }
    }
}
