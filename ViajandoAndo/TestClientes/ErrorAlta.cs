using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseDto;
using Data;
using ClaseDto;
using ClaseService;

namespace TestClientes
{
    public class ErrorAlta
    {
        List<Cliente> listado;
        ClienteService clienteService;
        ClientesDto clienteDto;
        [SetUp]
        public void Setup()
        {
            listado = ArchivoClientes.ObtenerCliente();
            clienteService = new ClienteService();

            clienteDto = new ClientesDto()
            {
                NombreClienteDto = "Jose",
                ApellidoClienteDto = "Ferreyra",
                EmailClienteDto = "Jorge@gmail.com",
                TelefonoDto = "3492000322",
                LocalidadDto = "Rafaela",
            };

        }

        [Test]
        public void AgregarClienteTest()
        {
            Validacion clienteNuevo = clienteService.AgregarCliente(clienteDto);

//Correcci´ón: faltan dos assertsmas. El test era que no se pueda cargar.
            Assert.That(clienteNuevo.Success, Is.True);
        }
    }
}
