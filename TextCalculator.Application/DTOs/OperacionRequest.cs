using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Application.Dtos
{
    public class OperacionRequest
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public string? Operacion { get; set; }
    }
}
