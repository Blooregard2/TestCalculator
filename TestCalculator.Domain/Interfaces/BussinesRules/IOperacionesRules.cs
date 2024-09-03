using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCalculator.Application.Dtos;

namespace TestCalculator.Domain.Interfaces.BussinesRules
{
    public interface IOperacionesRules
    {
        Task<OperacionResponse> RealizarOperacion(OperacionRequest request);
    }
}
