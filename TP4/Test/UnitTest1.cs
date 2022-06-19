using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            resultado = Biblioteca.Alumno.VerificacionCadena(cadena);

            // Assert
            Assert.AreEqual(expected, resultado);
        }
    }
}
