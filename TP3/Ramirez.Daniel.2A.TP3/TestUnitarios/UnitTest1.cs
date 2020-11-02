using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Prueba instancia Alumno
        /// </summary>
        [TestMethod]
        public void AlumnoPrueba()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(a1);
        }

        /// <summary>
        /// Prueba si la excepción lanzada es de tipo NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        public void NacionalidadInvalida()
        {
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, EntidadesInstanciables.Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                Assert.Fail();

            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Prueba si la excepción lanzada es de tipo AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void AlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234457", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            uni += a1;
            Alumno a2 = new Alumno(1, "José", "Gutierrez", "12234457", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            try
            {
                uni += a2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Prueba si se instancia la lista genérica de alumnos en Universidad
        /// </summary>
        [TestMethod]
        public void ListaInstanciada()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Alumnos);
        }

        /// <summary>
        /// Prueba que se lance DniInvalidoException
        /// </summary>
        [TestMethod]
        public void ValidacionDNI()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "kj72234457", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.Fail();
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
    }
}
