namespace LoginTresCapas.Models
{
    public class Usuario
    {
        public int IdUsuarios { get; set; }
        public string Nombreusuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public String Rol { get; set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
