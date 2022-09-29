using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNet.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "Seleccione un curso")]
        public string CursoId { get; set; }
        public Curso? Curso { get; set; }
        public List<Evaluación>? Evaluaciones { get; set; }
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public override string Nombre { set; get;}
    }
}