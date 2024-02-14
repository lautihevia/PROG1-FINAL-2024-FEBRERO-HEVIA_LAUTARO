using ClaseDto;
using Data;
namespace ClaseService
{
    public class ClienteService
    {
        private List<Cliente> listadoClientes;
        public ClienteService()
        {
            listadoClientes = ArchivoClientes.ObtenerCliente();
        }

        public Validacion AgregarCliente(ClientesDto clienteDto)
        {
            Validacion validacion = new Validacion();

            if (listadoClientes != null && listadoClientes.Exists(r => r.IdCliente == clienteDto.IdClienteDto))
            {
                validacion.Success = false;

                return validacion;
            }

            Cliente clienteNuevo = new Cliente()
            {
                NombreCliente = clienteDto.NombreClienteDto,
                ApellidoCliente = clienteDto.ApellidoClienteDto,
                EmailCliente = clienteDto.EmailClienteDto,
                TelefonoCliente = clienteDto.TelefonoDto,
                LocalidadCliente = clienteDto.LocalidadDto,
            };

            ArchivoClientes.GuardarCliente(clienteNuevo);

            clienteDto.IdClienteDto = clienteNuevo.IdCliente;

            validacion.Success = true;

            return validacion;
        }

        
        public List<Cliente> ObtenerClientes()
        {
            if (listadoClientes.Count != 0)
            {
                return listadoClientes;
            }
            return null;
        }

        
        public List<Cliente> ObtenerFiltrado(string? localidad, string? nombre)
        {
            if (localidad == null && nombre == null)
            {
                if (listadoClientes.Count != 0)
                {
                    return listadoClientes;
                }
            }
            else
            {
                if (localidad == null)
                {
                    foreach (var cliente in listadoClientes)
                    {
                        if (cliente.LocalidadCliente == localidad)
                        {
                            listadoClientes.Add(cliente);
                        }
                    }
                }
                else
                {
                    Cliente? clientePorNombre = ArchivoClientes.ObtenerCliente().FirstOrDefault(r => r.NombreCliente == nombre);
                }
            }

        }
        
    }
}
