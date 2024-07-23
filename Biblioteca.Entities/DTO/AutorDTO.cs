using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Biblioteca.Entities.DTO
{
    public class AutorDTO
    {
        public BigInteger Codigo { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(50,ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string NombreAutor { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener mas de 50 caracteres")]
        public string ApellidoAutor { get; set; }
    }
}
