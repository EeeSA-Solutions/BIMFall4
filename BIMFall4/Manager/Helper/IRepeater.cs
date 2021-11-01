using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMFall4.Manager.Helper
{
    public interface IRepeater<T>
    {
        List<T> CreateOnRepeat(T obj);
    }
}
