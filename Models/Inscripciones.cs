using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inscripcion.Models
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        [Required(ErrorMessage = "Es necesario Introducir un semestre")]
        public string Semestre { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un limite")]
        public int Limite { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una cantidad de creditos tomados")]
        [Range(typeof(int), minimum: "1", maximum: "300", ErrorMessage = "La cantidad de creditos tomados esta fuera de rango")]
        public int Tomados { get; set; }
        [Required(ErrorMessage = "Es necesario introducir la cantidad de creditos desponible")]
        [Range(typeof(int), minimum: "0", maximum: "300", ErrorMessage = "La cantidad de creditos disponibles esta fuera de rango")]
        public int Disponibles { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una fecha")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es necesario ingresar el Id del estudiante")]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un monto")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "Es necesario establecer un balance")]
        public decimal Balance { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Semestre = string.Empty;
            Limite = 0;
            Tomados = 0;
            Disponibles = 0;
            Fecha = DateTime.Now;
            EstudianteId = 0;
            Monto = 0;
            Balance = 0;
        }
    }
}
