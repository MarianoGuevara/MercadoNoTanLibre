using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializadora<T> where T : class
    {
        T Deserializar(string ruta);
        void Serializar(T obj, string ruta);
    }
}