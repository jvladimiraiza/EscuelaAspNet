using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNet.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion>? Evaluaciones { get; set; }
        [Required(ErrorMessage = "Seleccione un curso")]
        public string CursoId { get; set; }
        public Curso? Curso { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public override string Nombre { set; get;}
        [Required(ErrorMessage ="El campo apellidos es requerido")]
        public string Apellidos {set; get;}
    }
}