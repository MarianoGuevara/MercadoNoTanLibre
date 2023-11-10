using Entidades;

namespace UnitTest
{
    /// <summary>
    /// Clase dedicada a testear las sobrecargas operadores ==, != y + de 'productos'
    /// </summary>
    [TestClass]
    public class TestsUnitarios
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

        [TestMethod]
        public void EditarObjeto_Plataforma()
        {
            //Arrange
            Plataforma p1 = new Plataforma();

            Electrodomestico e1 = new Electrodomestico(ETipoProducto.Electrodomestico, 10,1,ETipoElecto.Lavaropa);
            Electrodomestico e2 = new Electrodomestico(ETipoProducto.Electrodomestico, 100, 10, ETipoElecto.Ventilador);

            p1 += e1;

            //Act
            p1.Editar(e2, 0);

            //Assert
            Assert.AreEqual(p1.ObjetosEnVenta[0], e2);
        }

        [TestMethod]
        public void EditarObjeto_Plataforma_Falla_FueraIndice()
        {
            //Arrange
            Plataforma p1 = new Plataforma();

            Electrodomestico e1 = new Electrodomestico(ETipoProducto.Electrodomestico, 10, 1, ETipoElecto.Lavaropa);
            Electrodomestico e2 = new Electrodomestico(ETipoProducto.Electrodomestico, 100, 10, ETipoElecto.Ventilador);

            p1 += e1;

            try
            {
                //Act
                p1.Editar(e2, 1);
            }
            catch (Exception ex) 
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }
    }
}