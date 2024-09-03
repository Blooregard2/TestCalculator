using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCalculator.Application.Dtos;

namespace TextCalculator.Application.Queries
{
    public interface IOperacionesQuery
    {
        Task<OperacionResponse> RealizarOperacion(OperacionRequest request);
    }
}
