using System;
using System.Collections.Generic;
using System.Text;
//No olvidar Agregar los siguientes [using].
using System.ComponentModel.DataAnnotations; //Este using permite usar [Key].

namespace RegistroUsuarios.Entidades //Nombre del proyecto.Entidades
{
    public class Usuarios //No olvidar agregarle [public] a la clase.
    {
        [Key] //No olvidar agregar [Key]
        public int UsuarioId { get; set; } // prop + tab + tab (para insertar automatico).
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}