using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("DNI inválido!!")
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException(Exception e) : base(e.Message, e)
        {

        }
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
