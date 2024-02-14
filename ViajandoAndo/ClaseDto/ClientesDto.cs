using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDto
{
    public class ClientesDto
    {
        public int IdClienteDto { get; set; }
        public string NombreClienteDto { get; set; }
        public string ApellidoClienteDto { get; set; }
        [EmailAddress]
        public string EmailClienteDto { get; set; }
        public string LocalidadDto { get; set; }
        public string TelefonoDto { get; set; }

        Validacion validacion;

        public ClientesDto()
        {
            validacion = new Validacion()
            {
                ListadoErrores = new List<Error>()
            };
        }

        public Validacion ValidarCliente()
        {
            if (string.IsNullOrWhiteSpace(NombreClienteDto))
            {
                validacion.ListadoErrores.Add(new Error() { ErrorEncontrado = "El nombre no puede estar vacio" });
            }

            if (string.IsNullOrWhiteSpace(ApellidoClienteDto))
            {
                validacion.ListadoErrores.Add(new Error() { ErrorEncontrado = "El apellido no puede estar vacio" });
            }
            if (string.IsNullOrWhiteSpace(LocalidadDto))
            {
                validacion.ListadoErrores.Add(new Error() { ErrorEncontrado = "La localidad no puede estar vacia" });
            }

            if (validacion.ListadoErrores.Count != 0)
            {
                validacion.Success = false;
            }

            return validacion;
        }
    }
}
