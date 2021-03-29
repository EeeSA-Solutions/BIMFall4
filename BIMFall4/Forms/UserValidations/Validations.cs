using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Forms.UserValidations
{
    // validation for unique email
    public class EmailValidation: BaseValidateHandler
    {
        public override void Validate(User user)
        {
            if(UserManager.GetUserByEmail(user.Email) != null)
            {
                throw new Exception("This email is already in use!");
            }
            else
            {
                base.Validate(user);
            }
        }
    }

    // validation for the length of tha pw
    public class PasswordValidation: BaseValidateHandler
    {
        public override void Validate(User user)
        {
            if (user.Password.Length < 8)
            {
                throw new Exception("Password must be more than 8 characters");
            }
            else
            {
                base.Validate(user);
            }
        }
    }
}