namespace Data
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TelefonoCliente { get; set; }
        public string LocalidadCliente { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
