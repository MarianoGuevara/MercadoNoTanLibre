using Entidades;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Program program = new Program();
        double a = program.VerificarParseo<double>("4645.1f4");
        Console.WriteLine($"tipo: {a.GetType()} || valor: {a}");

        ////List<Usuario> l1 = new List<Usuario>();

        ////usuarioDesarrollador d1 = new usuarioDesarrollador("marianio", "mas", "a", 1, 1, ETipoUsuario.UsuarioDesarrollador, 2, 4);
        ////usuarioNoPremium up1 = new usuarioNoPremium("cn", "marianomail");
        ////usuarioPremium u1 = new usuarioPremium("nico", "nasdsddd");

        ////l1.Add(d1);
        ////l1.Add(up1);
        ////l1.Add(u1);

        ////foreach (Usuario usuario in l1)
        ////{
        ////    Console.WriteLine(usuario.ToString());
        ////    Console.WriteLine("------------------------------------------");
        ////}
        ////string a = Regex.Match("hola@gmail.co", @"[A-Z|a-z]+@gmail.com").ToString();
        //Plataforma plataforma = new Plataforma();
        //Ropa r1 = new Ropa(ETipoRopa.Pantalon);
        //Ropa r2 = new Ropa(ETipoProducto.Ropa, 13, 55, ETipoRopa.Pantalon);
        //Electrodomestico e1 = new Electrodomestico(ETipoElecto.Lavaropa);
        //Electrodomestico e3 = new Electrodomestico(ETipoElecto.Lavaropa);
        //Electrodomestico e2 = new Electrodomestico(ETipoProducto.Electrodomestico, 3, 5, ETipoElecto.Lavaropa);
        //Alimento a1 = new Alimento(ETipoAlimento.Carne);

        //plataforma += a1;
        //plataforma += a1;
        //plataforma += e1;
        //plataforma += r1;
        //plataforma += r1;
        //plataforma += r2;

        //Console.WriteLine(e3.Equals(e1));
        //Console.WriteLine("------------------------------------");
        //foreach (ObjetoEnVenta obj in plataforma.ObjetosEnVenta)
        //{
        //    Console.WriteLine(obj.Equals(e3));
        //    Console.WriteLine(obj.ToString());
        //    Console.WriteLine("------------------------------------------");
        //}
        ////Console.WriteLine($"{a}");
    }
    public T VerificarParseo<T>(string dato)
    {
        try
        {
            T resultado = (T)Convert.ChangeType(dato, typeof(T));
            return resultado;
        }
        catch
        {
            throw;
        }
    }

}