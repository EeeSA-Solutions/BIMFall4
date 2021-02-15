using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMFall4.Forms
{
    public interface IForm
    {
        string ErrorMessage { get; }
        bool isValid();
    }
}
