using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Application.Dtos
{
    public class OperacionResponse
    {
        public double Total {  get; set; }
        public string Mensaje { get; set; }
        public List<int> Factores { get; set; } // Lista de factores 
    }
}
