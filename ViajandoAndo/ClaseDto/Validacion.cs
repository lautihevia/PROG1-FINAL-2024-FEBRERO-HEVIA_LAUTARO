using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDto
{
    public class Validacion
    {
        public Validacion()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public List<Error> ListadoErrores { get; set; }
    }
}
