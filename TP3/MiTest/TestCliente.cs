using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;

namespace MiTest
{
    [TestClass]
    public class TestCliente
    {
        /// <summary>
        /// Test de la validacion de la cadena.
        /// </summary>
        [TestMethod]
        public void ValidaCadena_CuandoRecibeUnaCadena_DeberiaRetornarCadenaVacia()
        {
            // Arrange
            string cadena = "Pablo";
            string expected = string.Empty;
            string resultado;
            
            // Act
            resultado = Biblioteca.Empleado.VerificacionCadena(cadena);

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
            resultado = Biblioteca.Empleado.VerificacionSalario(salario);

            // Assert
            Assert.AreEqual(expected, resultado);
        }
    }
}
