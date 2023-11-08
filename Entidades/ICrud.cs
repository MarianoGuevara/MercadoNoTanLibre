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


        //bool CrearObjeto<T>(T obj) where T : class;
        //U Parsear<U> (string obj) where U : struct;
        //bool VerificarLargo<V>(V obj, int minimoLargo) where V : struct;
    }
}
