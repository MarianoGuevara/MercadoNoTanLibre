using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IConversorImplicito<T> where T : Enum
    {
        public string DeEnumParaString(T obj);
        public T DeStringParaEnum(string obj);
    }
}
