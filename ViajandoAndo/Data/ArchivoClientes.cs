using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ArchivoClientes
    {
        private readonly static string RutaArchivoClientes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivoClientes.json");

        public static Cliente GuardarCliente(Cliente clienteData)
        {
            var listadoCliente = ObtenerCliente();

            if (clienteData.IdCliente != 0)
            {
                listadoCliente.RemoveAll(x => x.IdCliente == clienteData.IdCliente);
            }
            else
            {
                clienteData.IdCliente = listadoCliente.Count + 1;
            }

            listadoCliente.Add(clienteData);

            string datosParaArchivo = JsonConvert.SerializeObject(listadoCliente, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(RutaArchivoClientes, datosParaArchivo);

            return clienteData;
        }
        public static List<Cliente> ObtenerCliente()
        {
            if (!File.Exists(RutaArchivoClientes))
            {
                return new List<Cliente>();
            }
            string contenido = File.ReadAllText(RutaArchivoClientes);
            List<Cliente> listaFinal = JsonConvert.DeserializeObject<List<Cliente>>(contenido);
            return listaFinal;
        }
    }
}
