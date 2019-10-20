using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuota
    {
        public int IdCuota { get; set; }
        public double Valor { get; set; }
        public bool Pagada { get; set; }
    }
}
