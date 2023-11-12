using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ICrud<T> where T : class
    {
        void Agregar(T objetoDelCrud);
        void Eliminar(T objetoDelCrud);
        void Editar(T objetoEditCrud, int indiceListaCrud);
        void Editar(T objetoEditCrud, T objetoOriginal);

        // no implementa 'Read' ya que cada CRUD tiene una manera distinta de mostrar 
        // su info, y necesita distintos parametros o etc.
    }
}