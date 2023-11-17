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
        /// Verifica el funcionamiento del == entre 2 usuarios, en caso de ser ambos objetos iguales
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

        /// <summary>
        /// Verifica el funcionamiento del == entre 2 usuarios, en caso de ser ambos objetos diferentes,
        /// por el password
        /// </summary>
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

        /// <summary>
        /// Verifica el funcionamiento del == entre 2 usuarios, en caso de ser ambos objetos diferentes,
        /// por el mail
        /// </summary>
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

        /// <summary>
        /// Verifica el funcionamiento del == entre 2 usuarios, siendo ambos nulos
        /// </summary>
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

        /// <summary>
        /// Verifica la modificacion de un objeto de la lista de objetos en venta
        /// </summary>
        [TestMethod]
        public void EditarObjeto_Plataforma_OK()
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

        /// <summary>
        /// Verifica uno de los errores probables en la modificacion de un objeto de la lista de objetos en venta
        /// </summary>
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
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }

        /// <summary>
        /// Verifica la eliminacion de un objeto de la lista de objetos en venta
        /// </summary>
        [TestMethod]
        public void EliminarObjeto_Plataforma_OK()
        {
            //Arrange
            Plataforma p1 = new Plataforma();

            Ropa r1 = new Ropa(ETipoProducto.Ropa, 10, 1, ETipoRopa.Pantalon);

            p1 += r1;

            //Act
            p1.Eliminar(r1);
            bool noEsta = p1 != r1;

            //Assert
            Assert.IsTrue(noEsta);
        }

        /// <summary>
        /// Verifica el metodo parsear de la clase VerficadoraDeValidez
        /// </summary>
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

        /// <summary>
        /// Verifica el error en el metodo parsear de la clase VerficadoraDeValidez
        /// </summary>
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

        /// <summary>
        /// Verifica el metodo VerificarLargoString de la clase VerficadoraDeValidez
        /// si el string pasado esta OK
        /// </summary>
        [TestMethod]
        public void ClaseVerificadoraVerificarLargoString_OK()
        {
            //Arrange
            VerficadoraDeValidez v1 = new VerficadoraDeValidez();

            //Act
            bool largo = v1.VerificarLargoString("12345", 5);

            //Assert
            Assert.IsTrue(largo);
        }

        /// <summary>
        /// Verifica el retorno del metodo VerificarLargoString de la clase VerficadoraDeValidez
        /// si el string pasado es demasiado corto
        /// </summary>
        [TestMethod]
        public void ClaseVerificadoraVerificarLargoString_CORTO()
        {
            //Arrange
            VerficadoraDeValidez v1 = new VerficadoraDeValidez();

            //Act
            bool largo = v1.VerificarLargoString("12345", 6);

            //Assert
            Assert.IsFalse(largo);
        }
    }
}
/*
Asserts usados:
    -Assert.IsTrue
    -Assert.IsFalse
    -Assert.AreEqual
    -Assert.Fail
    -Assert.IsInstanceOfType
*/