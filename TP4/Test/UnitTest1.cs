using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;

namespace Test
{
    [TestClass]
    public class TestPersona
    {
        /// <summary>
        /// Test de la validacion de la cadena.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string cadena = "Pablo";
            string expected = string.Empty;
            string resultado;

            // Act
            resultado = Biblioteca.Alumno.verificacionCadena(cadena);

            // Assert
            Assert.AreEqual(expected, resultado);
        }

        /// <summary>
        /// Teste de la validacion del salario.
        /// </summary>
        [TestMethod]
        public void ValidaSalario_CuandoRecibeUnaCadena_DeberiaRetornarCadenaVacia()
        {
            // Arrange
            string salario = "40000";
            string expected = string.Empty;
            string resultado;

            // Act
            resultado = Biblioteca.Profesor.verificacionSalario(salario);

            // Assert
            Assert.AreEqual(expected, resultado);
        }
    }
}
