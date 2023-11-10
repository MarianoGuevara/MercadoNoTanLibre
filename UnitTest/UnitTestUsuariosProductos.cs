using Entidades;

namespace UnitTest
{
    /// <summary>
    /// Clase dedicada a testear las sobrecargas operadores ==, != y + de 'productos'
    /// </summary>
    [TestClass]
    public class UnitTestUsuariosProductos
    {
        /// <summary>
        /// Verifica 1 de las variantes del funcionamiento del == entre 2 usuarios
        /// </summary>
        [TestMethod]
        public void VerificarUsuariosIguales()
        {
            //Arrange
            Usuario u1 = new Usuario("Juan", "Perez", "juanceto123", "j@gmail.com", 123, "vendedor");
            Usuario u2 = new Usuario("Juan", "Perez", "juanceto123", "j@gmail.com", 123, "vendedor");

            //Act
            bool prueba = u1 == u2;

            //Assert
            Assert.IsTrue(prueba);
        }

        [TestMethod]
        public void VerificarUsuariosDiferentesPasswords()
        {
            //Arrange
            Usuario u1 = new Usuario("Juan", "Perez", "juanceto", "j@gmail.com", 123, "vendedor");
            Usuario u2 = new Usuario("Juan", "Perez", "juanceto123", "j@gmail.com", 123, "vendedor");

            //Act
            bool prueba = u1 == u2;

            //Assert
            Assert.IsFalse(prueba);
        }

        [TestMethod]
        public void VerificarUsuariosDiferentesCorreos()
        {
            //Arrange
            Usuario u1 = new Usuario("Juan", "Perez", "juanceto123", "j123@gmail.com", 123, "vendedor");
            Usuario u2 = new Usuario("Juan", "Perez", "juanceto123", "j@gmail.com", 123, "vendedor");

            //Act
            bool prueba = u1 == u2;

            //Assert
            Assert.IsFalse(prueba);
        }

        [TestMethod]
        public void VerificarUsuariosNulos()
        {
            //Arrange
            Usuario u1 = null;
            Usuario u2 = null;

            //Act
            bool prueba = u1 == u2;

            //Assert
            Assert.IsTrue(prueba);
        }

        [TestMethod]
        public void ClaseVerificadoraParsearCorrecto()
        {
            //Arrange
            VerficadoraDeValidez v1 = new VerficadoraDeValidez();

            //Act
            int resultado = v1.Parsear<int>("5");

            //Assert
            Assert.AreEqual(resultado, 5);
        }

        [TestMethod]
        public void ClaseVerificadoraParsearError()
        {
            //Arrange
            VerficadoraDeValidez v1 = new VerficadoraDeValidez();
            try
            {
                //Act
                int resultado = v1.Parsear<int>("5e");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(FormatException));
            }
        }
    }
}