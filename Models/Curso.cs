using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNet.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { set; get;}
        public TiposJornada Jornada { get; set; }
        public  List <Asignatura>? Asignaturas{ get; set; }
        public List<Alumno>? Alumnos{ get; set; }

        public string? Direccion { get; set; }

        public string? EscuelaId { get; set; }
        public Escuela? Escuela{ get; set; }
    }
}