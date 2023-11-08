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
    }
}