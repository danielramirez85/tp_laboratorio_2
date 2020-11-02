using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region "Campos"
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region "Constructores"
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.DNI = dni;
            }
            catch (NacionalidadInvalidaException e)
            {
                throw e;
            }

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.ToDNI = dni;
            }
            catch (DniInvalidoException e)
            {
                throw e;
            }
            catch (NacionalidadInvalidaException e) 
            {
                throw e;
            }
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Descriptor Set solo si el dato contiene caracteres válidos
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Descriptor Set solo si el DNI tiene valores válidos para la nacionalidad.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Descriptor Set solo si el dato contiene caracteres válidos (letras)
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Descriptor Set solo si el DNI tiene conversión válida
        /// </summary>
        public string ToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Verifica que el DNI esté entre valores válidos de extranjeros o argentinos.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato > 89999999 || dato < 1))
                throw new NacionalidadInvalidaException("Fuera de rango dni Argentino");
            if (nacionalidad == ENacionalidad.Extranjero && (dato < 90000000 || dato > 99999999))
                throw new NacionalidadInvalidaException("Fuera de rango dni Extranjero");
            return dato;
        }
        /// <summary>
        /// Convierte dato a entero previa validación que no contenga caracteres inválidos y valores dentro del rango
        /// para cada nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            Regex reg = new Regex("[0-9]");
            try
            {
                if (reg.IsMatch(dato))
                {
                    if (int.TryParse(dato, out int res))
                        return this.ValidarDni(nacionalidad, res);
                    else
                        throw new DniInvalidoException("Parseo incorrecto");
                }
                else
                    throw new DniInvalidoException("No debe contener caracteres o letras");
            }
            catch (NacionalidadInvalidaException e)
            {
                throw e;
            }
            catch (DniInvalidoException e)
            {
                throw new DniInvalidoException("Excepcion método Validar DNI",e);
            }
        }
        /// <summary>
        /// Verifica que el dato recibido tenga caractares válidos para ser nombre o apellido.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)  // test unitario o recodificar metodo
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
                return dato;
            return "";
        }
        /// <summary>
        /// Publica todos los datos de Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            s.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            s.AppendFormat("DNI: {0}", this.DNI.ToString());
            return s.ToString();
        }
        #endregion

        #region "Tipos Anidados"
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
