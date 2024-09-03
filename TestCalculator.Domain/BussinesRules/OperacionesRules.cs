using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCalculator.Domain.Interfaces.BussinesRules;
using TextCalculator.Application.Dtos;

namespace TestCalculator.Domain.BussinesRules
{
    public class OperacionesRules : IOperacionesRules
    {
        public async Task<OperacionResponse> RealizarOperacion(OperacionRequest request)
        {
            // Validar la solicitud antes de proceder con las operaciones
            var validationResult = ValidarSolicitud(request);
            if (validationResult != null)
            {
                return validationResult;
            }

            OperacionResponse response = new OperacionResponse();

            try
            {
                switch (request.Operacion)
                {
                    case "+":
                        response = await Sumar(request);
                        break;
                    case "-":
                        response = await Restar(request);
                        break;
                    case "*":
                        response = await Multiplicar(request);
                        break;
                    case "/":
                        if (request.Valor2 == 0)
                        {
                            return new OperacionResponse
                            {
                                Total = double.NaN,
                                Mensaje = "No se puede dividir por cero."
                            };
                        }
                        response = await Dividir(request);
                        break;
                    case "!":
                        response = await Factorizar(request);
                        break;
                    default:
                        return new OperacionResponse
                        {
                            Total = double.NaN,
                            Mensaje = "Operación no válida. Las operaciones permitidas son: +, -, *, /, !."
                        };
                }
            }
            catch (Exception ex)
            {
                return new OperacionResponse
                {
                    Total = double.NaN,
                    Mensaje = $"Error interno del servidor: {ex.Message}"
                };
            }

            response.Mensaje = "Operación realizada con éxito.";
            return response;
        }

        private OperacionResponse ValidarSolicitud(OperacionRequest request)
        {
            if (request == null)
            {
                return new OperacionResponse
                {
                    Total = double.NaN,
                    Mensaje = "Datos de solicitud no proporcionados."
                };
            }

            if (string.IsNullOrWhiteSpace(request.Operacion) ||
                (request.Operacion != "+" && request.Operacion != "-" && request.Operacion != "*" && request.Operacion != "/" && request.Operacion != "!"))
            {
                return new OperacionResponse
                {
                    Total = double.NaN,
                    Mensaje = "Operación no válida. Las operaciones permitidas son: +, -, *, /, !."
                };
            }

            // Validación para valores numéricos; solo se realiza si la operación es suma, resta, multiplicación o división
            if (request.Operacion != "!" && (double.IsNaN(request.Valor1) || double.IsNaN(request.Valor2)))
            {
                return new OperacionResponse
                {
                    Total = double.NaN,
                    Mensaje = "Los valores proporcionados deben ser números válidos."
                };
            }

            return null;
        }

        private async Task<OperacionResponse> Sumar(OperacionRequest request)
        {
            return new OperacionResponse
            {
                Total = request.Valor1 + request.Valor2
            };
        }

        private async Task<OperacionResponse> Restar(OperacionRequest request)
        {
            return new OperacionResponse
            {
                Total = request.Valor1 - request.Valor2
            };
        }

        private async Task<OperacionResponse> Multiplicar(OperacionRequest request)
        {
            return new OperacionResponse
            {
                Total = request.Valor1 * request.Valor2
            };
        }

        private async Task<OperacionResponse> Dividir(OperacionRequest request)
        {
            if (request.Valor2 == 0)
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }

            return new OperacionResponse
            {
                Total = request.Valor1 / request.Valor2
            };
        }

        private async Task<OperacionResponse> Factorizar(OperacionRequest request)
        {
            if (request.Valor1 < 0)
            {
                return new OperacionResponse
                {
                    Total = double.NaN,
                    Mensaje = "El número para factorizar debe ser no negativo."
                };
            }

            var factores = FactorizarNumero((int)request.Valor1);
            var mensaje = factores.Count > 0 ? "Factorización realizada con éxito." : "No se encontraron factores.";

            return new OperacionResponse
            {
                Total = double.NaN, // Para factorización, no se devuelve un total, sino los factores
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
