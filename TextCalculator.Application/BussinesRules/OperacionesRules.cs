using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextCalculator.Application.Dtos;

namespace TextCalculator.Application.BusinessRules
{
    public class OperacionesRules
    {
       

        public async Task<OperacionResponse> Sumar(OperacionRequest request)
        {
            return new OperacionResponse
            {
                Total = request.Valor1 + request.Valor2
                ,
                Mensaje = "La suma se realizo con éxito"
            };
        }

        public async Task<OperacionResponse> Restar(OperacionRequest request)
        {
            return new OperacionResponse
            {
                Total = request.Valor1 - request.Valor2,
                Mensaje = "La resta se realizo con éxito"
            };
        }

        public async Task<OperacionResponse> Multiplicar(OperacionRequest request)
        {
            return new OperacionResponse
            {
                Total = request.Valor1 * request.Valor2,
                Mensaje = "La multiplicacion se realizo con éxito"
            };
        }

        public async Task<OperacionResponse> Dividir(OperacionRequest request)
        {
            if (request.Valor2 == 0)
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }

            return new OperacionResponse
            {
                Total = request.Valor1 / request.Valor2,
                Mensaje = "La division se realizo con éxito"

            };
        }

        public async Task<OperacionResponse> Factorizar(OperacionRequest request)
        {
            if (request.Valor1 < 0)
            {
                throw new Exception("\"El número para factorizar debe ser no negativo.\"");                
            }

            var factores = FactorizarNumero((int)request.Valor1);
            var mensaje = factores.Count > 0 ? "Factorización realizada con éxito." : "No se encontraron factores.";

            return new OperacionResponse
            {
                Total = 0, // Para factorización, no se devuelve un total, sino los factores
                Mensaje = mensaje,
                Factores = factores
            };
        }

        private List<int> FactorizarNumero(int numero)
        {
            var factores = new List<int>();
            for (int i = 2; i <= numero; i++)
            {
                while (numero % i == 0)
                {
                    factores.Add(i);
                    numero /= i;
                }
            }
            return factores;
        }
    }
}
