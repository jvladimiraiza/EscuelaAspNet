using System;
using System.ComponentModel.DataAnnotations;

namespace aspNet.Models
{
    public class Evaluacion:ObjetoEscuelaBase
    {
        public Alumno? Alumno { get; set; }
        [Required(ErrorMessage = "Seleccione un alumno")]
        public string AlumnoId { get; set; }
        public Asignatura? Asignatura  { get; set; }
        [Required(ErrorMessage = "Seleccione una asignatura")]
        public string AsignaturaId { get; set; }
        [Required(ErrorMessage = "La nota es requerida")]
        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}