using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroUsuarios.BLL //Nombre del proyecto.BLL
{
    public class Utilidades //No olvidar agregarle [public] a la clase.
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);
            return retorno;
        }
    }
}