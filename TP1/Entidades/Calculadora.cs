﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza operacion entre Numeros recibidos previa validacion del operador aritmetico.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "/":
                    return num1 / num2;
                case "*":
                    return num1 * num2;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// Valida que el parametro sea un operador aritmetico, caso contrario asigna operador +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "-" || operador == "*" || operador == "/" || operador == "+")
                return operador;
            else
                return "+";
        }
        #endregion
    }
}
