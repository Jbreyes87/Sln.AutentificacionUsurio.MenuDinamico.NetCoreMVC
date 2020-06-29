using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Emsoir.Dominio.Entity
{
    public class Categoria
    {
       //[ExplicitKey]
       [Dapper.Contrib.Extensions.Key]
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }
}
