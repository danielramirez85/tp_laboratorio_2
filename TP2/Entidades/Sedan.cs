using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region "Atributos"
        private ETipo tipo;
        #endregion

        #region "Tipos Anidados"
        public enum ETipo 
        { 
            CuatroPuertas, CincoPuertas 
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : this(marca,chasis,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestra toda la información de un Sedan
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
