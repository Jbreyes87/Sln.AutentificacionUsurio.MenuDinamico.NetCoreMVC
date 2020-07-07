using System.ComponentModel.DataAnnotations;
namespace Emsoir.Dominio.Entity.Models
{
    public class Usuario
    {
        [Dapper.Contrib.Extensions.Key]
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }

    }
}
