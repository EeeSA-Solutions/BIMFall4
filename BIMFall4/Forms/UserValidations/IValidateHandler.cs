using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMFall4.Forms.UserValidations
{
    public interface IValidateHandler
    {
        void SetNextValidator(IValidateHandler validator);
        void Validate(User user);
    }
}
