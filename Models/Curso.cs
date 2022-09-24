using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNet.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public override string Nombre { set; get;}
        [Required(ErrorMessage ="Seleccione un tipo de jornada")]
        public TiposJornada? Jornada { get; set; }
        public  List <Asignatura>? Asignaturas{ get; set; }
        public List<Alumno>? Alumnos{ get; set; }

        public string? Direccion { get; set; }

        public string? EscuelaId { get; set; }
        public Escuela? Escuela{ get; set; }
    }
}