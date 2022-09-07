using System;
using System.ComponentModel.DataAnnotations;

namespace aspNet.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        public virtual string Nombre { get; set; } // virtual => puede ser modificado por las clase hijos

        public ObjetoEscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}