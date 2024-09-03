using System;
using System.Threading.Tasks;
using TextCalculator.Application.Dtos;
using TextCalculator.Application.BusinessRules;

namespace TextCalculator.Application.Queries
{
    public class OperacionesQuery : IOperacionesQuery
    {
        private readonly OperacionesRules _operacionesRules;

        public OperacionesQuery(OperacionesRules operacionesRules)
        {
            _operacionesRules = operacionesRules;
        }

        public async Task<OperacionResponse> RealizarOperacion(OperacionRequest request)
        {
           
            OperacionResponse response = new OperacionResponse();
            try
            {
                // Delegar la operación a la lógica de negocio correspondiente
                switch (request.Operacion)
                {
                    case "+":
                        response = await _operacionesRules.Sumar(request);
                        break;
                    case "-":
                        response = await _operacionesRules.Restar(request);
                        break;
                    case "*":
                        response = await _operacionesRules.Multiplicar(request);
                        break;
                    case "/":
                        if (request.Valor2 == 0)
                        {
                            response.Total = double.NaN;
                            response.Mensaje = "No se puede dividir por cero.";
                            return response;
                        }
                        response = await _operacionesRules.Dividir(request);
                        break;
                    case "!":
                        response = await _operacionesRules.Factorizar(request);                       
                        break;
                    default:
                        throw new Exception("Operación no válida.");
                }

               
            }
            catch (Exception ex)
            {
                response.Total = double.NaN;
                response.Mensaje = $"Error interno del servidor: {ex.Message}";
            }

            return response;
        }
    }
}
