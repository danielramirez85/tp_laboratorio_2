using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException() : base("Sin profesor para la materia!!")
        {

        }
    }
}
