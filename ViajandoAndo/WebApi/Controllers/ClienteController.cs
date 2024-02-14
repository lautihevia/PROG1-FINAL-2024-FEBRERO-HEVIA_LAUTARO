using Microsoft.AspNetCore.Mvc;
using ClaseService;
using ClaseDto;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        ClienteService clienteService;

        public ClienteController()
        {
            clienteService = new ClienteService();
        }

        [HttpPost]
        public IActionResult AgregarCliente([FromBody] ClientesDto cliente)
        {
            var validacion = cliente.ValidarCliente();

            var resultado = validacion.ListadoErrores.Select(e => new { ErrorEncontrado = e.ErrorEncontrado }).ToList();

            if (!validacion.Success)
            {
                return BadRequest(resultado);
            }

            var validar = clienteService.AgregarCliente(cliente);

            if (validar.Success)
            {
                return Ok(cliente);
            }
            return BadRequest("No se pudo cargar, ya existe un cliente con esos datos");
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<ClientesDto>> ObtenerListado()
        {
            var validar = clienteService.ObtenerClientes();

            if (validar != null)
            {
                return Ok(validar);
            }
            return BadRequest("El listado no existe");
        }

        
        
        
        


    }
}
