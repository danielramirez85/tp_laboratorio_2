using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        /// <summary>
        /// Atributo donde se asigna el valor numerico a operar.
        /// </summary>
        private double numero;
        #endregion

        #region constructores
        /// <summary>
        /// Construsctor por default: asigna el valor 0 a numero reutilizando código.
        /// </summary>
        public Numero() : this(0)
        {
            
        }
        /// <summary>
        /// Constructor recibe string para validar que sea un valor numerico antes de asignarlo a numero.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Constructor asigna el valor recibido al atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad asigna el valor recibido previa validacion de que sea un valor numerico.
        /// </summary>
        private string SetNumero
        {
            set { this.numero = this.ValidarNumero(value); }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo valida que el string recibido contenga valores numericos y lo retorna en double, caso contrario retorna 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            if (decimal.TryParse(strNumero.Replace('.', ','), out decimal resultado))
                return (double)resultado;
            return 0;
        }
        /// <summary>
        /// Comprueba si el parámetro recibido contiene valores de 0 o 1.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario.Substring(i, 1) != "0" && binario.Substring(i, 1) != "1")
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Realiza conversión de Binario a Decimal 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            int resultadoOperacion = 0;
            int j = 0;
            decimal numeroValidacion = 0;

            if (decimal.TryParse(binario, out numeroValidacion))
                numeroValidacion = Math.Truncate(numeroValidacion);

            if (numeroValidacion < 0)
                numeroValidacion = numeroValidacion * -1;

            binario = numeroValidacion.ToString();

            if (this.EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    if (binario.Substring(i, 1) == "0")
                        resultadoOperacion += 0;
                    else if ((binario.Substring(i, 1) == "1"))
                        resultadoOperacion += (int)Math.Pow(2, j);

                    j++;
                }
                return resultadoOperacion.ToString();
            }
            else
                return "Valor inválido";
        }
        /// <summary>
        /// Realiza conversión de Decimal a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string strNumero = "";
            int modulo;
            string strResultado = "";

            if (numero < 0)
                numero = numero * -1;

            if (numero != 0)
            {
                while (numero > 0)
                {
                    modulo = (int)numero % 2;
                    numero = (numero - modulo) / 2;
                    if (modulo == 0)
                        strNumero += "0";
                    else
                        strNumero += "1";
                }
                for (int i = (strNumero.Length - 1); i >= 0; i--)
                {
                    strResultado += strNumero.Substring(i, 1);
                }
            }
            else
                return "Valor invalido";

            return strResultado;
        }
        /// <summary>
        /// Realiza conversión de Decimal a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            if (decimal.TryParse(numero, out decimal nroDecimal))
            {
                int parteEntera = (int)nroDecimal;
                return this.DecimalBinario(parteEntera);
            }
            else
                return "Valor inválido";
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Operador + realiza operacion suma entre dos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Operador - realiza operacion resta entre dos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Operador * realiza operacion multiplicacion entre dos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Operador / realiza operacion division siempre y cuando los dos operandos sean diferentes a 0
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2) 
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return double.MinValue;
        }
        #endregion
    }
}
