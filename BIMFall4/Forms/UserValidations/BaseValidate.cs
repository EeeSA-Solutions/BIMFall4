using BIMFall4.Forms;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Forms.UserValidations
{
    public abstract class BaseValidateHandler: IValidateHandler
    {
        protected IValidateHandler nextChain;

        public void SetNextValidator(IValidateHandler chain)
        {
            nextChain = chain;
        }

        public virtual void Validate(User user)
        {
            if(nextChain != null)
                nextChain.Validate(user);
        }
    }
}