using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base("Error al intentar leer o guardar!!", innerException)
        {

        }
    }
}
